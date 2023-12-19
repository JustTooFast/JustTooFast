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

using System.Collections.Generic;

namespace JustTooFast.BidFast;

/// <summary>
/// Holds the data points used by <see cref="BuilderGenerator"/>,
/// <see cref="InfoGenerator"/>, and <see cref="DeclarationGenerator"/>
/// to generate Builder, Info, and Declaration classes.
/// </summary>
public class BidEntity
{
    private readonly List<string> m_Attributes = new();
    private readonly List<string> m_Entities = new();
    private readonly List<string> m_AttributeSets = new();
    private readonly List<string> m_EntitySets = new();

    /// <summary>
    /// The root name of the Builder, Info, Declaration classes.
    /// </summary>
    public string Name
    { get; set;}
    
    /// <summary>
    /// Each attribute is a single data point that can be
    /// used to generate code.
    /// </summary>
    public List<string> Attributes
    {
        get { return m_Attributes; }
    }

    /// <summary>
    /// Each entity is a reference to a single child component
    /// that can generate its own code.
    /// </summary>
    public List<string> Entities
    {
        get { return m_Entities; }
    }

    /// <summary>
    /// Each attribute set is a collection of related data
    /// points that can be used to generate code.
    /// </summary>
    public List<string> AttributeSets
    {
        get { return m_AttributeSets; }
    }

    /// <summary>
    /// Each entity set is a collection of related child
    /// components that can generate their own code.
    /// </summary>
    public List<string> EntitySets
    {
        get { return m_EntitySets; }
    }
}
