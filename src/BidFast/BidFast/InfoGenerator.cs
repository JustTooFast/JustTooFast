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
/// Generates an Info class which is responsible for holding the
/// data points that will be used by a Declaration class to 
/// generate code.
/// <seealso cref="DeclarationGenerator"/>
/// </summary>
public class InfoGenerator : IGenerator
{
    private readonly BidEntity m_Entity;
    private readonly string m_TargetNamespace;

    public InfoGenerator(BidEntity entity, string targetNamespace)
    {
        m_Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        
        if(string.IsNullOrWhiteSpace(targetNamespace))
            throw new ArgumentNullException(nameof(targetNamespace));

        m_TargetNamespace = targetNamespace;
    }

    /// <summary>
    /// Generates an Info class based on the <see cref="BidEntity"/>
    /// and targetNamespace.
    /// </summary>
    /// <returns>Generated Info class.</returns>
    public string Generate()
    {
        StringBuilder sb = new();

        //Add usings
        sb.AppendLineFeed("using System.Collections.Generic;");

        sb.AppendLineFeed();

        //Add namespace and class
        sb.AppendLineFeed($"namespace {m_TargetNamespace};")
            .AppendLineFeed($"public partial class {m_Entity.Name}Info")
            .AppendLineFeed("{");

       bool isFirstElement = true;

        //Add fields for each attribute set
        foreach (string attributeSet in m_Entity.AttributeSets)
        {
            if (isFirstElement)
            {
                isFirstElement = false;
            }

            sb.AppendLineFeed($"    private readonly List<string> m_{attributeSet.ToPlural()} = new();");
        }

        //Add fields for each entity set
        foreach (string entitySet in m_Entity.EntitySets)
        {
            if (isFirstElement)
            {
                isFirstElement = false;
            }

            sb.AppendLineFeed($"    private readonly List<{entitySet}Info> m_{entitySet.ToPlural()} = new();");
        }

        //Add properties for each attribute
        foreach (string attribute in m_Entity.Attributes)
        {
            if (!isFirstElement)
            {
                sb.AppendLineFeed();
            }
            else
            {
                isFirstElement = false;
            }

            sb.AppendLineFeed($"    public string {attribute}")
                .AppendLineFeed("    { get; set; }");
        }

        //Add properties for each entity
        foreach (string entity in m_Entity.Entities)
        {
            if (!isFirstElement)
            {
                sb.AppendLineFeed();
            }
            else
            {
                isFirstElement = false;
            }

            sb.AppendLineFeed($"    public {entity}Info {entity}")
                .AppendLineFeed("    { get; set; }");
        }

        //Add properties for each attribute set
        foreach (string attributeSet in m_Entity.AttributeSets)
        {
            if (!isFirstElement)
            {
                sb.AppendLineFeed();
            }
            else
            {
                isFirstElement = false;
            }

            string pluralAttributeSet = attributeSet.ToPlural();
            sb.AppendLineFeed($"    public List<string> {pluralAttributeSet}")
                .AppendLineFeed("    {")
                .AppendLineFeed($"        get {{ return m_{pluralAttributeSet}; }}")
                .AppendLineFeed("    }");
        }

        //Add properties for each entity set
        foreach (string entitySet in m_Entity.EntitySets)
        {
            if (!isFirstElement)
            {
                sb.AppendLineFeed();
            }
            else
            {
                isFirstElement = false;
            }

            string pluralEntitySet = entitySet.ToPlural();
            sb.AppendLineFeed($"    public List<{entitySet}Info> {pluralEntitySet}")
                .AppendLineFeed("    {")
                .AppendLineFeed($"        get {{ return m_{pluralEntitySet}; }}")
                .AppendLineFeed("    }");
        }

        //Close class
        sb.AppendLineFeed("}");

        string result = sb.ToString();

        return result;
    }
}
