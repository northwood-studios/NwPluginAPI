using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NWPluginAPI.Analyzers
{
	[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(NWPluginAPIAnalyzersCodeFixProvider)), Shared]
	public class NWPluginAPIAnalyzersCodeFixProvider : CodeFixProvider
	{
		public sealed override ImmutableArray<string> FixableDiagnosticIds
		{
			get { return ImmutableArray.Create(NWPluginAPIAnalyzersAnalyzer.WrongParameterDiagnosticId, NWPluginAPIAnalyzersAnalyzer.MissingParameterDiagnosticId, NWPluginAPIAnalyzersAnalyzer.MissingParametersDiagnosticId, NWPluginAPIAnalyzersAnalyzer.ParameterNotRequiredDiagnosticId); }
		}

		public sealed override FixAllProvider GetFixAllProvider()
		{
			return WellKnownFixAllProviders.BatchFixer;
		}

		public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
		{
			var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

			foreach(var diagnostic in context.Diagnostics)
			{
				var diagnosticSpan = diagnostic.Location.SourceSpan;

				var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<MethodDeclarationSyntax>().First();

				switch (diagnostic.Id)
				{
					case NWPluginAPIAnalyzersAnalyzer.WrongParameterDiagnosticId:
						context.RegisterCodeFix(
							CodeAction.Create(
								title: "Replace parameter",
								createChangedDocument: c => ReplaceParameterAsync(context.Document, diagnostic.Properties, declaration, c),
								equivalenceKey: "Replace parameter"),
							diagnostic);
						break;
					case NWPluginAPIAnalyzersAnalyzer.MissingParameterDiagnosticId:
						context.RegisterCodeFix(
							CodeAction.Create(
								title: "Add parameter",
								createChangedDocument: c => AddParameterAsync(context.Document, diagnostic.Properties, declaration, c),
								equivalenceKey: "Add parameter"),
							diagnostic);
						break;
					case NWPluginAPIAnalyzersAnalyzer.MissingParametersDiagnosticId:
						context.RegisterCodeFix(
							CodeAction.Create(
								title: "Add parameters",
								createChangedDocument: c => AddParametersAsync(context.Document, diagnostic.Properties, declaration, c),
								equivalenceKey: "Add parameters"),
							diagnostic);
						break;
				}
			}
		}

		private async Task<Document> ReplaceParameterAsync(Document document, ImmutableDictionary<string, string> properties, MethodDeclarationSyntax method, CancellationToken token)
		{
			var root = await document.GetSyntaxRootAsync();

			var updatedMethod = method.AddParameterListParameters(
				SyntaxFactory.Parameter(
					SyntaxFactory.Identifier("amogus"))
					.WithType(SyntaxFactory.ParseTypeName("PluginAPI.Core.Player")));

			var updatedSyntaxTree = root.ReplaceNode(method, updatedMethod);

			return document.WithSyntaxRoot(updatedSyntaxTree);
		}

		private async Task<Document> AddParameterAsync(Document document, ImmutableDictionary<string, string> properties, MethodDeclarationSyntax method, CancellationToken token)
		{
			var root = await document.GetSyntaxRootAsync();

			if (!properties.TryGetValue("parameterType", out string type)) return document;
			if (!properties.TryGetValue("parameterName", out string name)) return document;

			var updatedMethod = method.AddParameterListParameters(
				SyntaxFactory.Parameter(
					SyntaxFactory.Identifier(name))
					.WithType(SyntaxFactory.ParseTypeName(type)));

			var updatedSyntaxTree = root.ReplaceNode(method, updatedMethod);

			return document.WithSyntaxRoot(updatedSyntaxTree);
		}

		private async Task<Document> AddParametersAsync(Document document, ImmutableDictionary<string, string> properties, MethodDeclarationSyntax method, CancellationToken token)
		{
			var root = await document.GetSyntaxRootAsync();


			List<ParameterSyntax> parameters = new List<ParameterSyntax>();

			foreach (var prop in properties)
			{
				parameters.Add(
					SyntaxFactory.Parameter(
						SyntaxFactory.Identifier(prop.Key)).WithType(SyntaxFactory.ParseTypeName(prop.Value)));
			}

			MethodDeclarationSyntax updatedMethod = method.AddParameterListParameters(parameters.ToArray());

			var updatedSyntaxTree = root.ReplaceNode(method, updatedMethod);

			return document.WithSyntaxRoot(updatedSyntaxTree);
		}
	}
}
