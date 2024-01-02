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

namespace JustTooFast.Xml;
public partial class RootElementDeclaration : DeclarationBase
{
    public RootElementDeclaration(RootElementInfo rootElement, IAppender appender)
        : this(rootElement)
    {
        Appender = appender;
    }

    private partial void Validate()
    {
        if (string.IsNullOrWhiteSpace(m_RootElement.Name))
            throw new XmlFormatException("RootElement Name is required.");
    }

    public override void AppendDeclaration()
    {
        Appender.Append($"<{m_RootElement.Name}");

        foreach (AttributeInfo attribute in m_RootElement.Attributes)
        {
            Appender.Append(' ');
            AttributeDeclaration attributeDeclaration = new(attribute, Appender);
            attributeDeclaration.AppendDeclaration();
        }

        Appender.Append('>');

        foreach (ElementInfo element in m_RootElement.Elements)
        {
            Appender.AppendLineFeed();
            ElementDeclaration elementDeclaration = new(element, Appender)
            {
                TabLevel = 1
            };
            elementDeclaration.AppendDeclaration();
        }

        if (m_RootElement.Elements.Count > 0)
            Appender.AppendLineFeed();

        Appender.Append($"</{m_RootElement.Name}>");
    }
}