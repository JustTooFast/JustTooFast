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
/// Contract for converting from a "bid" domain specific language (DSL)
/// file into a <see cref="BidEntity"/> object.
/// </summary>
public interface IBidParser
{
    /// <summary>
    /// Parses file formatted with "bid" DSL into a
    /// <see cref="BidEntity"/> object.
    /// </summary>
    /// <param name="file">The "bid" DSL file to parse.</param>
    /// <returns>The resulting <see cref="BidEntity"/> object.</returns>
    BidEntity Parse(File file);
}
