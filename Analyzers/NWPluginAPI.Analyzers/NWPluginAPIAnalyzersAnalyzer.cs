using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using NWPluginAPI.Analyzers.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace NWPluginAPI.Analyzers
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class NWPluginAPIAnalyzersAnalyzer : DiagnosticAnalyzer
	{
		public const string ParameterNotRequiredDiagnosticId = "NWAPIRP";
		public const string WrongParameterDiagnosticId = "NWAPIWP";
		public const string MissingParameterDiagnosticId = "NWAPIMP";
		public const string MissingParametersDiagnosticId = "NWAPIMPS";


		private static readonly DiagnosticDescriptor ParameterNotRequiredRule = new DiagnosticDescriptor(ParameterNotRequiredDiagnosticId,
			"Parameter not required",
			"Parameter '{0}' is not used in this event!",
			"Naming",
			DiagnosticSeverity.Error,
			isEnabledByDefault: true);

		private static readonly DiagnosticDescriptor WrongParameterRule = new DiagnosticDescriptor(WrongParameterDiagnosticId,
			"Wrong type used",
			"Type '{0}' is not used in this event, use type '{1}'!",
			"Naming",
			DiagnosticSeverity.Error,
			isEnabledByDefault: true);

		private static readonly DiagnosticDescriptor MissingParameterRule = new DiagnosticDescriptor(MissingParameterDiagnosticId,
			"Missing parameter",
			"Parameter of type '{0}' is missing in this event!",
			"Naming",
			DiagnosticSeverity.Error,
			isEnabledByDefault: true);

		private static readonly DiagnosticDescriptor MissingParametersRule = new DiagnosticDescriptor(MissingParametersDiagnosticId,
			"Missing parameters",
			"Parameters of type '{0}' are missing in this event!",
			"Naming",
			DiagnosticSeverity.Error,
			isEnabledByDefault: true);


		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(ParameterNotRequiredRule, WrongParameterRule, MissingParameterRule, MissingParametersRule); } }

		public override void Initialize(AnalysisContext context)
		{
			context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
			context.EnableConcurrentExecution();
			context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Method);
		}

		private static void AnalyzeSymbol(SymbolAnalysisContext context)
		{
			var methodSymbol = (IMethodSymbol)context.Symbol;

			INamedTypeSymbol attribute = context.Compilation.GetTypeByMetadataName("PluginAPI.Core.Attributes.PluginEvent");

			INamedTypeSymbol eventTypeEnum = context.Compilation.GetTypeByMetadataName("PluginAPI.Enums.ServerEventType");

			var eventAttribute = methodSymbol.GetAttributes().FirstOrDefault(x => SymbolEqualityComparer.Default.Equals(x.AttributeClass, attribute));

			if (eventAttribute == null) return;

			var eventType = eventAttribute.ConstructorArguments.FirstOrDefault(x => SymbolEqualityComparer.Default.Equals(x.Type, eventTypeEnum));

			if (eventType.IsNull) return;

			if (!(eventType.Value is int eventNum)) return;

			if (!EventManager.Events.TryGetValue(eventNum, out Event ev)) return;

			List<INamedTypeSymbol> requiredSymbols = new List<INamedTypeSymbol>();

			for (int x = 0; x < ev.Parameters.Length; x++)
			{
				requiredSymbols.Add(context.Compilation.GetTypeByMetadataName(ev.Parameters[x].BaseType));
			}

			List<ActionType> result = new List<ActionType>();

			for (int x = 0; x < ev.Parameters.Length; x++)
			{
				result.Add(ActionType.Add);
			}

			for (int x = 0; x < methodSymbol.Parameters.Length; x++)
			{
				var parameter = methodSymbol.Parameters[x];

				if (requiredSymbols.Count < x + 1)
				{
					var diagTooMuchParams = Diagnostic.Create(ParameterNotRequiredRule, parameter.Locations[0], parameter.Name);

					context.ReportDiagnostic(diagTooMuchParams);
					result.Add(ActionType.Remove);
					continue;
				}

				if (parameter.Type.TypeKind == requiredSymbols[x].TypeKind)
				{
					if (parameter.Type.SpecialType == SpecialType.System_Array && ev.Parameters[x].IsArray)
					{
						result[x] = ActionType.None;
						continue;
					}

					if (ev.Parameters[x].IsArray)
					{
						var diagReplace = Diagnostic.Create(WrongParameterRule, parameter.Locations[0], parameter.Type.Name, requiredSymbols[x].Name);

						context.ReportDiagnostic(diagReplace);
						result[x] = ActionType.Replace;
						continue;
					}
				}
				else
				{
					if (requiredSymbols[x].AllInterfaces.Length != 0)
					{
						if (context.Compilation.IsSymbolAccessibleWithin(requiredSymbols[x], parameter.Type))
						{
							result[x] = ActionType.None;
							continue;
						}
					}

					var diagWrongParam = Diagnostic.Create(WrongParameterRule, parameter.Locations[0], parameter.Type.Name, requiredSymbols[x].Name);

					context.ReportDiagnostic(diagWrongParam);
					result[x] = ActionType.Replace;
					continue;
				}

				result[x] = ActionType.None;
			}

			Dictionary<int, EventParameter> missingParameters = new Dictionary<int, EventParameter>();

			for (int x = 0; x < result.Count; x++)
			{
				if (result[x] != ActionType.Add) continue;

				missingParameters.Add(x, ev.Parameters[x]);
			}

			if (missingParameters.Count != 0)
			{
				Dictionary<string, string> paramsToAdd = new Dictionary<string, string>()
				{
					{ "eventId", eventNum.ToString() }
				};

				string missingParams = string.Empty;
				string missingParamsStr = string.Empty;

				foreach (var missingParam in missingParameters)
				{
					missingParams += $"{missingParam.Key},";
					missingParamsStr += $"{missingParam.Value.BaseType}, ";
				}

				missingParams = missingParams.Substring(0, missingParams.Length - 1);

				paramsToAdd.Add("parameters", missingParams);

				missingParamsStr = missingParamsStr.Substring(0, missingParamsStr.Length - 2);

				if (missingParams.Length == 1)
				{
					var diagMissingParam = Diagnostic.Create(MissingParameterRule, methodSymbol.Locations[0], ImmutableDictionary.CreateRange<string, string>(paramsToAdd), missingParamsStr);
					context.ReportDiagnostic(diagMissingParam);
				}
				else
				{
					var diagMissingParams = Diagnostic.Create(MissingParametersRule, methodSymbol.Locations[0], ImmutableDictionary.CreateRange<string, string>(paramsToAdd), missingParamsStr);
					context.ReportDiagnostic(diagMissingParams);
				}
			}
		}
	}
}