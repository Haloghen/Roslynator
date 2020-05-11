﻿# Analyzer Options

Each analyzer option is represented by an "analyzer" that is is not real analyzer but rather a modification of its parent analyzer.

## Properties

Analyzer option has following properties:

* It has ID that is derived from its parent analyzer (RCS0000 can have option RCS0000a, RCS0000b etc.).
* It is displayed in section "Options" in documentation of its parent analyzer.
* It requires its parent analyzer to be enabled.
* It is never reported as a diagnostic.

## Example

Analyzer [RCS1051](analyzers/RCS1051.md) suggest to parenthesize each condition of conditional expression.

`x ? y : z` &ensp;>&ensp; `(x) ? y : z`

Long after this analyzer was introduced it was [proposed](https://github.com/JosefPihrt/Roslynator/issues/169) to keep condition without parentheses if it is a single token.
That is reasonable proposal. It could be solved just by adding new analyzer, ID let's say RCS1234.
But that would be very confusing for the user because no one expects that there should be some connection between RCS1051 and RCS1234.

Solution to this proposal it to add new "analyzer option" [RCS1051a](analyzers/RCS1051a.md) which changes behavior of RCS1051 in a following manner:

* Parenthesize condition only in cases where expression is not a single token.
  * `x != null ? y : z` &ensp;>&ensp; `(x != null) ? y : z`
* Remove parentheses from condition if it is a single token.
  * `(x) ? y : z` &ensp;>&ensp; `x ? y : z`

## Types of Analyzer Options

### "Enable" Option 

This option will cause additional case(s) to be reported by its parent analyzer. Example is [RCS1036a](analyzers/RCS1036a.md).

### "Disable" Option

This option will cause some case(s) not to be reported by its parent analyzer. Example is [RCS1246a](analyzers/RCS1246a.md).

### "Change" Option

This option is combination of "Enable" and "Disable" option. Example is [RCS1051a](analyzers/RCS1051a.md).

### "Invert" Option

This option inverts behavior of its parent analyzer. For example instead of adding some kind of a syntax
it will suggest to remove the syntax.
