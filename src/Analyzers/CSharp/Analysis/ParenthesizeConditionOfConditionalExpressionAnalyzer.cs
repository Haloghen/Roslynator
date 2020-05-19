﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Roslynator.CSharp.Syntax;

namespace Roslynator.CSharp.Analysis
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ParenthesizeConditionOfConditionalExpressionAnalyzer : BaseDiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get { return ImmutableArray.Create(DiagnosticDescriptors.ParenthesizeConditionOfConditionalExpression); }
        }

        public override void Initialize(AnalysisContext context)
        {
            base.Initialize(context);

            context.RegisterSyntaxNodeAction(AnalyzeConditionalExpression, SyntaxKind.ConditionalExpression);
        }

        private static void AnalyzeConditionalExpression(SyntaxNodeAnalysisContext context)
        {
            var conditionalExpression = (ConditionalExpressionSyntax)context.Node;

            if (conditionalExpression.ContainsDiagnostics)
                return;

            ConditionalExpressionInfo info = SyntaxInfo.ConditionalExpressionInfo(conditionalExpression, walkDownParentheses: false);

            if (!info.Success)
                return;

            if (info.Condition.Kind() == SyntaxKind.ParenthesizedExpression)
                return;

            DiagnosticHelpers.ReportDiagnostic(context, DiagnosticDescriptors.ParenthesizeConditionOfConditionalExpression, info.Condition);
        }
    }
}
