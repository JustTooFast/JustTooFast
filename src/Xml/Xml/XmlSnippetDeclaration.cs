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
public partial class XmlSnippetDeclaration : DeclarationBase
{
    public XmlSnippetDeclaration(XmlSnippetInfo xmlSnippet, IAppender appender)
        : this(xmlSnippet)
    {
        Appender = appender;
    }

    private partial void Validate()
    {
        if (m_XmlSnippet.Elements.Count == 0)
            throw new XmlFormatException("XmlSnippet missing Elements.");
    }
    
    public override void AppendDeclaration()
    {
        bool isFirst = true;
        foreach (ElementInfo element in m_XmlSnippet.Elements)
        {
            //Skip line feed on first element
            if(isFirst)
                isFirst = false;
            else
                Appender.AppendLineFeed();

            ElementDeclaration elementDeclaration = new(element, Appender);
            elementDeclaration.AppendDeclaration();
        }
    }
}