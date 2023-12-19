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

namespace JustTooFast.BidFast;

/// <summary>
/// Contract for writing generated Builder, Info, and Declaration classes.
/// </summary>
public interface IBidWriter
{
    /// <summary>
    /// Converts "bid" domain specific language (DSL) input files into
    /// generated builder, info, and declaration classes and writes
    /// them to an output folder.
    /// </summary>
    /// <param name="inputFolder">The folder holding "bid" DSL files to be parsed.</param>
    /// <param name="outputFolder">The folder where generated classes are written.</param>
    /// <returns>The number of written files.</returns>
    int Write(string inputFolder, string outputFolder, string targetNamespace);
}
