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
public partial class XmlFileDeclaration : DeclarationBase
{
    public XmlFileDeclaration(XmlFileInfo xmlFile, IAppender appender)
        : this(xmlFile)
    {
        Appender = appender;
    }

    private partial void Validate()
    {
        //Ensure Prolog is initialized
        m_XmlFile.Prolog ??= new PrologInfo();

        if (m_XmlFile.RootElement == null)
            throw new XmlFormatException("XmlFile RootElement is required.");
    }
    
    public override void AppendDeclaration()
    {
        if (!m_XmlFile.DisableProlog)
        {
            PrologDeclaration prologDeclaration = new(m_XmlFile.Prolog, Appender);
            prologDeclaration.AppendDeclaration();

            Appender.AppendLineFeed();
        }

        RootElementDeclaration rootElementDeclaration = new(m_XmlFile.RootElement, Appender);
        rootElementDeclaration.AppendDeclaration();
    }
}