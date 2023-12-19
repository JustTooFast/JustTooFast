// Copyright 2023 Matthew Yancer
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Text;

namespace JustTooFast.BidFast;

/// <summary>
/// Provides StringBuilder extension methods.
/// </summary>
public static class StringBuilderEx
{
    /*
    NOTE: It appears that .NET Core has an implementation
    for StringBuilder.AppendLine using Environment.NewLine.
    The default behavor for VS Code and Visual Studio is to use LF (\n)
    for C# files whether in Linux or Windows. This means the
    verbatim string literals used in BidFast.Tests also use LF (\n) by
    default. Everything works fine on Linux since
    Environment.NewLine will also be LF (\n). But on Windows,
    Environment.NewLine becomes CRLF (\r\n). This causes unit tests to
    fail since the verbatim string literals and generated strings
    do not have matching line endings. OS should not be the only factor
    to determine line endings -- the type of file should also
    be factored in. Since this library is using StringBuilder to
    create C# files specifically, adding extension methods to
    StringBuilder to control the specific type of line ending used in
    order to guarantee matching with unit tests and ensure C# output
    uses LF (\n) just like it would from VS Code and Visual Studio.
    */

    /// <summary>
    /// Appends a line feed character. (LF, \n)
    /// </summary>
    /// <param name="sb">The StringBuilder being appended to.</param>
    /// <returns>The StringBuilder, for further method chaining.</returns>
    public static StringBuilder AppendLineFeed(this StringBuilder sb)
    {
        if(sb == null)
            throw new ArgumentNullException(nameof(sb));

        return sb.Append('\n');
    }

    /// <summary>
    /// Appends a string value and a line feed character. (LF, \n)
    /// </summary>
    /// <param name="sb">The StringBuilder being appended to.</param>
    /// <param name="value">The string value to append.</param>
    /// <returns>The StringBuilder, for further method chaining.</returns>
    public static StringBuilder AppendLineFeed(this StringBuilder sb, string value)
    {
        if(sb == null)
            throw new ArgumentNullException(nameof(sb));

        return sb.AppendFormat("{0}\n", value);
    }
}