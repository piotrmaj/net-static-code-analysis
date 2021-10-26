using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Sample.App.Stylistic
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DateTimeNowDiagnosticAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "MY0001";

        private const string Title = "DateTime.Now should not be used.";

        private const string MessageFormat = "By default we prevent using DateTime.Now because except maybe a few rare cases we should always use DateTime.UtcNow";

        private const string Category = "Dates";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
            DiagnosticId,
            Title,
            MessageFormat,
            Category,
            DiagnosticSeverity.Warning,
            description: MessageFormat,
            isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
            => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.RegisterSyntaxNodeAction(AnalyzeSymbol, SyntaxKind.IdentifierName);
        }

        private static void AnalyzeSymbol(SyntaxNodeAnalysisContext context)
        {
            SyntaxToken token = context.Node.GetFirstToken();
            if (token.ToString().Equals("DateTime"))
            {
                SyntaxToken nextToken = token.GetNextToken();

                if (nextToken.IsKind(SyntaxKind.DotToken))
                {
                    SyntaxToken dateTimeProperty = nextToken.GetNextToken();
                    if (dateTimeProperty.ToString().Equals("Now"))
                    {
                        context.ReportDiagnostic(Diagnostic.Create(Rule, context.Node.GetLocation()));
                    }
                }
            }
        }
    }
}
