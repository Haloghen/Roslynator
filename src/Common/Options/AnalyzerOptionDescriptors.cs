﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Roslynator.Options
{
    public static partial class AnalyzerOptionDescriptors
    {
        private static DiagnosticDescriptorFactory Factory { get; } = new DiagnosticDescriptorFactory(AnalyzerRules.Default);
    }
}