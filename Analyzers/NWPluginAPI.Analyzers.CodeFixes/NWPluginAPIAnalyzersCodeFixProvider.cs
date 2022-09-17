using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
			get { return ImmutableArray.Create(NWPluginAPIAnalyzersAnalyzer.DiagnosticId); }
		}

		public sealed override FixAllProvider GetFixAllProvider()
		{
			// See https://github.com/dotnet/roslyn/blob/main/docs/analyzers/FixAllProvider.md for more information on Fix All Providers
			return WellKnownFixAllProviders.BatchFixer;
		}

		public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
		{
			var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

			// TODO: Replace the following code with your own analysis, generating a CodeAction for each fix to suggest
			var diagnostic = context.Diagnostics.First();
			var diagnosticSpan = diagnostic.Location.SourceSpan;

			// Find the type declaration identified by the diagnostic.
			var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<MethodDeclarationSyntax>().First();

			// Register a code action that will invoke the fix.
			context.RegisterCodeFix(
				CodeAction.Create(
					title: "Add missing parameters",
					createChangedDocument: c => MakeUppercaseAsync(context.Document, declaration, c),
					equivalenceKey: nameof(CodeFixResources.CodeFixTitle)),
				diagnostic);
		}

		private async Task<Document> MakeUppercaseAsync(Document document, MethodDeclarationSyntax param, CancellationToken cancellationToken)
		{
			var attribute = SyntaxFactory.AttributeList(
	SyntaxFactory.SingletonSeparatedList<AttributeSyntax>(
		SyntaxFactory.Attribute(SyntaxFactory.IdentifierName("PluginEvent"), null)));
						
			var newParam = param.WithAttributeLists(param.AttributeLists.Add(attribute));

			var root = await document.GetSyntaxRootAsync();
			var newRoot = root.ReplaceNode(param, newParam);
			var newDocument = document.WithSyntaxRoot(newRoot);

			return newDocument;
		}
	}
}
