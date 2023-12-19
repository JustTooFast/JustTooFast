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

namespace JustTooFast.SampleXml;
public partial class AttributeDeclaration
{
    public partial string Generate()
    {
        string result = string.Empty;
        if (string.IsNullOrWhiteSpace(m_Attribute.Value))
            result = $"{m_Attribute.Name}=\"\"";
        else
            result = $"{m_Attribute.Name}=\"{m_Attribute.Value}\"";
        
        return result;
    }
}
