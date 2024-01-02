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

namespace JustTooFast.Xml;
public abstract class DeclarationBase
{
    private IAppender m_Appender;

    public IAppender Appender
    {
        protected get
        {
            if (m_Appender == null)
                throw new Exception("Appender is not initialized.");
            else
                return m_Appender;
        }
        set
        {
            m_Appender = value;
        }
    }

    public abstract void AppendDeclaration();

    public override string ToString()
    {
        return m_Appender.ToString();
    }
}
