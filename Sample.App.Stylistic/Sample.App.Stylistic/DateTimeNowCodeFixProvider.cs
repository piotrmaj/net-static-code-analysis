using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;

namespace Sample.App.Stylistic
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(DateTimeNowCodeFixProvider))]
    [Shared]
    public class DateTimeNowCodeFixProvider : CodeFixProvider
    {
        private const string CodeFixTitle = "Refactor code to use DateTime.UtcNow";

        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(DateTimeNowDiagnosticAnalyzer.DiagnosticId);

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            Diagnostic diagnostic = context.Diagnostics.First();

            switch (diagnostic.Id)
            {
                case DateTimeNowDiagnosticAnalyzer.DiagnosticId:
                    context.RegisterCodeFix(
                        CodeAction.Create(
                            title: CodeFixTitle,
                            createChangedDocument: c => CodeFix(context, c),
                            equivalenceKey: CodeFixTitle),
                        diagnostic);
                    break;
                default:
                    break;
            }

            return Task.CompletedTask;
        }

        private static async Task<Document> CodeFix(CodeFixContext context, CancellationToken cancellationToken)
        {
            SyntaxNode root = await context.Document.GetSyntaxRootAsync(cancellationToken);
            Diagnostic diagnostic = context.Diagnostics.First();
            SyntaxToken nowToken = root
                .FindToken(diagnostic.Location.SourceSpan.Start)
                .GetNextToken()
                .GetNextToken();
            SyntaxNode newRoot = root.ReplaceToken(nowToken, SyntaxFactory.Identifier("UtcNow"));
            return context.Document.WithSyntaxRoot(newRoot);
        }
    }
}
