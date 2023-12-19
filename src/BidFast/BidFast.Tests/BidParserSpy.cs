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

namespace JustTooFast.BidFast.Tests;
public class BidParserSpy : IBidParser
{
    public int CallsTo_Parse
    { get; set; }

    public BidEntity Parse(File file)
    {
        CallsTo_Parse++;

        BidEntity entity = new();

        if (file.Path.Contains("First"))
            entity.Name = "First";
        else if (file.Path.Contains("Second"))
            entity.Name = "Second";

        string[] lines = file.Contents.SplitIntoLines();

        if (lines.Length > 0)
        {
            if (lines[0] != "--")
            {
                entity.Attributes.Add(lines[0]);
            }
        }

        return entity;
    }
}
