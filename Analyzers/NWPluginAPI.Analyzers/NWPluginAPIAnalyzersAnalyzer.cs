using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;

namespace NWPluginAPI.Analyzers
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class NWPluginAPIAnalyzersAnalyzer : DiagnosticAnalyzer
	{
		public const string ParameterNotRequiredDiagnosticId = "NWPluginAPIAnalyzersParameterNotRequired";
		public const string WrongParameterDiagnosticId = "NWPluginAPIAnalyzersWrongParameter";
		public const string MissingParameterDiagnosticId = "NWPluginAPIAnalyzersMissingParameter";
		public const string MissingParametersDiagnosticId = "NWPluginAPIAnalyzersMissingParameters";


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

			var eventAttribute = methodSymbol.GetAttributes().FirstOrDefault(x => x.AttributeClass.Equals(attribute));

			if (eventAttribute != null)
			{
				var eventType = eventAttribute.ConstructorArguments.FirstOrDefault(x => x.Type.Equals(eventTypeEnum));

				if (eventType.IsNull) return;

				if (!(eventType.Value is int eventNum)) return;

				if (!GeneratedRequiredParameters.RequiredParameters.TryGetValue(eventNum, out string[] types)) return;

				List<INamedTypeSymbol> requiredSymbols = new List<INamedTypeSymbol>();

				foreach(var type in types)
				{
					requiredSymbols.Add(context.Compilation.GetTypeByMetadataName(type));
				}

				List<INamedTypeSymbol> symbolsToCheck = new List<INamedTypeSymbol>(requiredSymbols);

				for(int x = 0; x < methodSymbol.Parameters.Length; x++)
				{
					var parameter = methodSymbol.Parameters[x];

					if (requiredSymbols.Count < x+1)
					{
						var diagTooMuchParams = Diagnostic.Create(ParameterNotRequiredRule, parameter.Locations[0], parameter.Name);

						context.ReportDiagnostic(diagTooMuchParams);
						symbolsToCheck.Remove(requiredSymbols[x]);
						continue;
					}

					if (!parameter.Type.TypeKind.Equals(requiredSymbols[x].TypeKind))
					{
						if (requiredSymbols[x].AllInterfaces.Length != 0)
						{
							if (context.Compilation.IsSymbolAccessibleWithin(requiredSymbols[x], parameter.Type))
							{
								symbolsToCheck.Remove(requiredSymbols[x]);
								continue;
							}
						}

						var diagWrongParam = Diagnostic.Create(WrongParameterRule, parameter.Locations[0], parameter.Type.Name, requiredSymbols[x].Name);

						context.ReportDiagnostic(diagWrongParam);
					}
					symbolsToCheck.Remove(requiredSymbols[x]);
				}

				if (symbolsToCheck.Count == 1)
				{
					ImmutableDictionary<string, string> missingParamParameters = ImmutableDictionary.Create<string, string>();
					missingParamParameters = missingParamParameters.Add("parameterType", symbolsToCheck[0].Name);
					missingParamParameters = missingParamParameters.Add("parameterName", $"arg1");

					var diagMissingParam = Diagnostic.Create(MissingParameterRule, methodSymbol.Locations[0], missingParamParameters, symbolsToCheck[0].MetadataName);

					context.ReportDiagnostic(diagMissingParam);
				}
				else if (symbolsToCheck.Count != 0)
				{
					string symbols = string.Empty;

					Dictionary<string, string> paramsToAdd = new Dictionary<string, string>();

					for(int x = 0; x < symbolsToCheck.Count; x++)
					{
						symbols += symbolsToCheck.Count == x + 1 ? $"{symbolsToCheck[x].Name}" : $"{symbolsToCheck[x].Name}, ";
						paramsToAdd.Add($"arg{x + 1}", symbolsToCheck[x].Name);
					}

					var diagMissingParams = Diagnostic.Create(MissingParametersRule, methodSymbol.Locations[0], ImmutableDictionary.CreateRange<string, string>(paramsToAdd), symbols);

					context.ReportDiagnostic(diagMissingParams);
				}
			}
		}
	}
}
