// Copyright (c) 2020-2023 DeNA Co., Ltd.
// This software is released under the MIT License.

using System.Collections.Immutable;
using System.Linq;
using BanAsyncTaskAnalyzer.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace BanAsyncTaskAnalyzer;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class BanAsyncTaskAnalyzer : DiagnosticAnalyzer
{
    private static readonly DiagnosticDescriptor Rule01 = new DiagnosticDescriptor(
        id: "BanAsyncTask0001",
        title: "Banned Task Rule",
        messageFormat: "Do not use '{0}', Should use UniTask",
        category: "Naming",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Type names should be all uppercase.");

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule01);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSymbolAction(AnalyzeAsyncMethod, SymbolKind.Method);
    }

    private static void AnalyzeAsyncMethod(SymbolAnalysisContext context)
    {
        var methodSymbol = (IMethodSymbol)context.Symbol;
        if (!methodSymbol.IsAsync)
        {
            return;
        }

        if (methodSymbol.ReturnType.FullName() == "System.Threading.Tasks.Task")
        {
            var diagnostic = Diagnostic.Create(Rule01, methodSymbol.Locations[0], methodSymbol.ReturnType);
            context.ReportDiagnostic(diagnostic);
        }
    }
}
