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

namespace JustTooFast.BidFast;

/// <summary>
/// Generates a Declaration class which is responsible for
/// generating code based on inputs from an Info object.
/// <seealso cref="InfoGenerator"/>
/// </summary>
public class DeclarationGenerator : IGenerator
{
    private readonly BidEntity m_Entity;
    private readonly string m_TargetNamespace;

    public DeclarationGenerator(BidEntity entity, string targetNamespace)
    {
        m_Entity = entity ?? throw new ArgumentNullException(nameof(entity));

        if(string.IsNullOrWhiteSpace(targetNamespace))
            throw new ArgumentNullException(nameof(targetNamespace));

        m_TargetNamespace = targetNamespace;
    }

    /// <summary>
    /// Generates a Declaration class based on the <see cref="BidEntity"/>
    /// and targetNamespace.
    /// </summary>
    /// <returns>Generated Declaration class.</returns>
    public string Generate()
    {
        StringBuilder sb = new();

        //Add usings
        sb.AppendLineFeed("using System;");

        sb.AppendLineFeed();

        //Add namespace and class
        sb.AppendLineFeed($"namespace {m_TargetNamespace};")
            .AppendLineFeed($"public partial class {m_Entity.Name}Declaration")
            .AppendLineFeed("{");

        //Add field for info
        sb.AppendLineFeed($"    private readonly {m_Entity.Name}Info m_{m_Entity.Name};");

        sb.AppendLineFeed();

        //Add constructor
        string camelCaseName = m_Entity.Name.ToLowerFirstLetter();
        sb.AppendLineFeed($"    public {m_Entity.Name}Declaration({m_Entity.Name}Info {camelCaseName})")
            .AppendLineFeed("    {")
            .AppendLineFeed($"        m_{m_Entity.Name} = {camelCaseName} ?? throw new ArgumentNullException(nameof({camelCaseName}));")
            .AppendLineFeed()
            .AppendLineFeed("        Validate();")
            .AppendLineFeed("    }");

        sb.AppendLineFeed();

        //Add validate method stub
        sb.AppendLineFeed("    private partial void Validate();");

        //Close class
        sb.AppendLineFeed("}");

        string result = sb.ToString();

        return result;
    }
}
