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

namespace JustTooFast.SampleXml;
public partial class ElementDeclaration
{
    public partial string Generate()
    {
        StringBuilder sb = new();

        sb.Append($"<{m_Element.Name}");
        
        foreach (AttributeInfo attribute in m_Element.Attributes)
        {
            AttributeDeclaration ad = new(attribute);
            sb.Append($" {ad.Generate()}");
        }

        sb.Append('>');


        if (!string.IsNullOrWhiteSpace(m_Element.Text))
        {
            sb.Append(m_Element.Text);
        }
        else
        {
            foreach (ElementInfo element in m_Element.Elements)
            {
                ElementDeclaration ed = new(element);
                sb.AppendLine()
                    .Append(Indent(ed.Generate()));
            }

            if (m_Element.Elements.Count > 0)
                sb.AppendLine();
        }

        sb.Append($"</{m_Element.Name}>");

        string result = sb.ToString();

        return result;
    }

    private string Indent(string str)
    {
        StringBuilder sb = new();

        string[] lines = str.Split(Environment.NewLine);

        for (int i = 0; i < lines.Length; i++)
        {
            sb.Append($"  {lines[i]}");

            if (i < lines.Length - 1)
                sb.AppendLine();
        }

        return sb.ToString();
    }
}
