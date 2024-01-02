// Copyright 2024 Matthew Yancer
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

using System.ComponentModel;

namespace JustTooFast.Xml;
public enum Encoding
{
    [Description("UTF-8")]
    UTF_8,

    [Description("UTF-16")]
    UTF_16,

    [Description("ISO-10646-UCS-2")]
    ISO_10646_UCS_2,

    [Description("ISO-10646-UCS-4")]
    ISO_10646_UCS_4,

    [Description("ISO-8859-1")]
    ISO_8859_1,

    [Description("ISO-8859-2")]
    ISO_8859_2,

    [Description("ISO-8859-3")]
    ISO_8859_3,

    [Description("ISO-8859-4")]
    ISO_8859_4,

    [Description("ISO-8859-5")]
    ISO_8859_5,

    [Description("ISO-8859-6")]
    ISO_8859_6,

    [Description("ISO-8859-7")]
    ISO_8859_7,

    [Description("ISO-8859-8")]
    ISO_8859_8,

    [Description("ISO-8859-9")]
    ISO_8859_9,

    [Description("ISO-2022-JP")]
    ISO_2022_JP,

    [Description("Shift_JIS")]
    Shift_JIS,

    [Description("EUC-JP")]
    EUC_JP,

    [Description("US-ASCII")]
    US_ASCII
}
