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

using System.Reflection.Metadata.Ecma335;

namespace JustTooFast.Xml;
public partial class AttributeDeclaration : DeclarationBase
{
    public AttributeDeclaration(AttributeInfo attribute, IAppender appender)
        : this(attribute)
    {
        Appender = appender;
    }

    private partial void Validate()
    {
        if (string.IsNullOrWhiteSpace(m_Attribute.Name))
            throw new XmlFormatException("Attribute Name is required.");
    }

    public override void AppendDeclaration()
    {
        Appender.Append($"{m_Attribute.Name}=\"");

        if (!string.IsNullOrWhiteSpace(m_Attribute.Value))
            Appender.Append(m_Attribute.Value);

        Appender.Append('\"');
    }
}