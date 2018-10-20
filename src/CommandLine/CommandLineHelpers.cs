﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Roslynator.Documentation;
using static Roslynator.CodeFixes.ConsoleHelpers;

namespace Roslynator.CommandLine
{
    internal static class CommandLineHelpers
    {
        public static bool TryParseMSBuildProperties(IEnumerable<string> values, out Dictionary<string, string> properties)
        {
            properties = new Dictionary<string, string>();

            foreach (string property in values)
            {
                int index = property.IndexOf("=");

                if (index == -1)
                {
                    WriteLine($"Unable to parse property '{property}'", ConsoleColor.Red);
                    return false;
                }

                string key = property.Substring(0, index);

                properties[key] = property.Substring(index + 1);
            }

            if (properties.Count > 0)
            {
                WriteLine("Add MSBuild properties");

                int maxLength = properties.Max(f => f.Key.Length);

                foreach (KeyValuePair<string, string> kvp in properties)
                    WriteLine($"  {kvp.Key.PadRight(maxLength)} = {kvp.Value}");
            }

            // https://github.com/Microsoft/MSBuildLocator/issues/16
            if (!properties.ContainsKey("AlwaysCompileMarkupFilesInSeparateDomain"))
                properties["AlwaysCompileMarkupFilesInSeparateDomain"] = bool.FalseString;

            return true;
        }

        public static bool TryParseDiagnosticSeverity(string value, out DiagnosticSeverity severity)
        {
            if (!Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out severity))
            {
                WriteLine($"Unknown diagnostic severity '{value}'.");
                return false;
            }

            return true;
        }

        public static bool TryParseIgnoredRootParts(IEnumerable<string> values, out RootDocumentationParts parts)
        {
            if (!values.Any())
            {
                parts = DocumentationOptions.Default.IgnoredRootParts;
                return true;
            }

            parts = RootDocumentationParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out RootDocumentationParts result))
                {
                    parts |= result;
                }
                else
                {
                    WriteLine($"Unknown root documentation part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        public static bool TryParseIgnoredNamespaceParts(IEnumerable<string> values, out NamespaceDocumentationParts parts)
        {
            if (!values.Any())
            {
                parts = DocumentationOptions.Default.IgnoredNamespaceParts;
                return true;
            }

            parts = NamespaceDocumentationParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out NamespaceDocumentationParts result))
                {
                    parts |= result;
                }
                else
                {
                    WriteLine($"Unknown namespace documentation part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        public static bool TryParseIgnoredTypeParts(IEnumerable<string> values, out TypeDocumentationParts parts)
        {
            if (!values.Any())
            {
                parts = DocumentationOptions.Default.IgnoredTypeParts;
                return true;
            }

            parts = TypeDocumentationParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out TypeDocumentationParts result))
                {
                    parts |= result;
                }
                else
                {
                    WriteLine($"Unknown type documentation part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        public static bool TryParseIgnoredMemberParts(IEnumerable<string> values, out MemberDocumentationParts parts)
        {
            if (!values.Any())
            {
                parts = DocumentationOptions.Default.IgnoredMemberParts;
                return true;
            }

            parts = MemberDocumentationParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out MemberDocumentationParts result))
                {
                    parts |= result;
                }
                else
                {
                    WriteLine($"Unknown member documentation part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        public static bool TryParseIgnoredDeclarationListParts(IEnumerable<string> values, out DeclarationListParts parts)
        {
            if (!values.Any())
            {
                parts = DeclarationListOptions.Default.IgnoredParts;
                return true;
            }

            parts = DeclarationListParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out DeclarationListParts result))
                {
                    parts |= result;
                }
                else
                {
                    WriteLine($"Unknown declaration list part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        public static bool TryParseOmitContainingNamespaceParts(IEnumerable<string> values, out OmitContainingNamespaceParts parts)
        {
            if (!values.Any())
            {
                parts = DocumentationOptions.Default.OmitContainingNamespaceParts;
                return true;
            }

            parts = OmitContainingNamespaceParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out OmitContainingNamespaceParts result))
                {
                    parts |= result;
                }
                else
                {
                    WriteLine($"Unknown omit containing namespace part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        public static bool TryParseVisibility(string value, out DocumentationVisibility visibility)
        {
            if (!Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out visibility))
            {
                WriteLine($"Unknown visibility '{value}'.");
                return false;
            }

            return true;
        }

        public static string GetLanguageName(string value)
        {
            if (string.Equals(value, "csharp", StringComparison.OrdinalIgnoreCase))
                return LanguageNames.CSharp;

            if (string.Equals(value, "vb", StringComparison.OrdinalIgnoreCase))
                return LanguageNames.VisualBasic;

            return null;
        }
    }
}
