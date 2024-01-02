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

namespace JustTooFast.Xml;
public partial class XmlDeclaration : DeclarationBase
{
    public XmlDeclaration(XmlInfo xml, IAppender appender)
        : this(xml)
    {
        Appender = appender;
    }

    private partial void Validate()
    {
        if(!(m_Xml.Standalone == null ||
            m_Xml.Standalone == Standalone.Yes.GetDescription() ||
            m_Xml.Standalone == Standalone.No.GetDescription()))
        {
            throw new XmlFormatException("Xml Standalone must be either 'yes', 'no', or not used.");
        }
    }
    
    public override void AppendDeclaration()
    {
        Appender.Append("<?xml version=\"1.0\"");

        if (m_Xml.Encoding != null)
            Appender.Append($" encoding=\"{m_Xml.Encoding}\"");

        if (m_Xml.Standalone != null)
            Appender.Append($" standalone=\"{m_Xml.Standalone}\"");

        Appender.Append("?>");
    }
}