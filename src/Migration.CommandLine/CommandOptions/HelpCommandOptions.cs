﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Roslynator.CommandLine
{
    internal sealed class HelpCommandOptions : AbstractCommandOptions
    {
        internal HelpCommandOptions()
        {
        }

        public string Command { get; internal set; }

        public bool IncludeValues { get; internal set; }

        public bool Manual { get; internal set; }
    }
}