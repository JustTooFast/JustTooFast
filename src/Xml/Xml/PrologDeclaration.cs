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
public partial class PrologDeclaration : DeclarationBase
{
    public PrologDeclaration(PrologInfo prolog, IAppender appender)
        : this(prolog)
    {
        Appender = appender;
    }

    private partial void Validate()
    {
        //Ensure Xml is initialized
        m_Prolog.Xml ??= new XmlInfo();
    }
    
    public override void AppendDeclaration()
    {
        XmlDeclaration xmlDeclaration = new(m_Prolog.Xml, Appender);
        xmlDeclaration.AppendDeclaration();
    }
}