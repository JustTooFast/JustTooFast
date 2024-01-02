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

namespace JustTooFast.Xml;
public partial class ElementDeclaration : DeclarationBase
{
    public ElementDeclaration(ElementInfo element, IAppender appender)
        : this(element)
    {
        Appender = appender;
    }

    public int TabLevel
    { get; set; }

    private partial void Validate()
    {
        if (string.IsNullOrWhiteSpace(m_Element.Name))
            throw new XmlFormatException("Element Name is required.");

        if ((m_Element.Text != null) && (m_Element.Elements.Count > 0))
            throw new XmlFormatException("Element cannot have both Text and Child Elements.");
    }

    public override void AppendDeclaration()
    {
        const string TAB = "  ";

        for(int i = 0; i < TabLevel; i++)
            Appender.Append(TAB);

        Appender.Append($"<{m_Element.Name}");

        foreach (AttributeInfo attribute in m_Element.Attributes)
        {
            Appender.Append(' ');

            AttributeDeclaration attributeDeclaration = new(attribute, Appender);
            attributeDeclaration.AppendDeclaration();
        }

        Appender.Append('>');

        if (!string.IsNullOrWhiteSpace(m_Element.Text))
        {
            Appender.Append(m_Element.Text);
        }
        else
        {
            foreach (ElementInfo element in m_Element.Elements)
            {
                Appender.AppendLineFeed();
                ElementDeclaration elementDeclaration = new(element, Appender)
                {
                    TabLevel = TabLevel + 1
                };
                elementDeclaration.AppendDeclaration();
            }

            if (m_Element.Elements.Count > 0)
                Appender.AppendLineFeed();
        }

        if(m_Element.Elements.Count > 0)
        {
            for(int i = 0; i < TabLevel; i++)
                Appender.Append(TAB);
        }

        Appender.Append($"</{m_Element.Name}>");
    }
}