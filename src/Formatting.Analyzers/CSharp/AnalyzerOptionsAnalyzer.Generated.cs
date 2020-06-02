﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// <auto-generated>

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Roslynator.Formatting.CSharp
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    internal class AnalyzerOptionsAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return ImmutableArray.Create(DiagnosticDescriptors.RemoveEmptyLineBetweenSingleLineAccessors, DiagnosticDescriptors.RemoveEmptyLineBetweenUsingDirectivesWithDifferentRootNamespace);
            }
        }

        public override void Initialize(AnalysisContext context)
        {
        }
    }
}