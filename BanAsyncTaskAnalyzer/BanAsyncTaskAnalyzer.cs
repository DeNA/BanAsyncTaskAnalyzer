// Copyright (c) 2020-2023 DeNA Co., Ltd.
// This software is released under the MIT License.

using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace BanAsyncTaskAnalyzer;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class BanAsyncTaskAnalyzer : DiagnosticAnalyzer
{
    internal const string DiagnosticId = "BanAsyncTaskAnalyzer0001";

    private static readonly DiagnosticDescriptor s_rule = new DiagnosticDescriptor(
        id: DiagnosticId,
        title: "Type name contains lowercase letters",
        messageFormat: "Type name '{0}' contains lowercase letters",
        category: "Naming",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Type names should be all uppercase.");

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(s_rule);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
    }
}
