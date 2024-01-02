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

using System;
using System.ComponentModel;
using System.Reflection;

namespace JustTooFast.Xml;
public static class EnumEx
{
    public static string GetDescription(this Enum value)
    {
        string result = value.ToString();

        Type enumType = value.GetType();
        MemberInfo[] memberInfo = enumType.GetMember(value.ToString());
        if ((memberInfo != null && memberInfo.Length > 0))
        {
            DescriptionAttribute[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if ((attributes != null) && (attributes.Length > 0))
            {
                result = attributes[0].Description;
            }
        }

        return result;
    }
}
