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
using System.IO;
using System.Text;

namespace JustTooFast.BidFast.Tests;

[TestClass]
public class BidParserTest
{
    [TestMethod]
    public void Parse_WithPath_ReturnName()
    {
        //Arrange
        File input = new()
        {
            Path = $"SomeFilePath{Path.DirectorySeparatorChar}MyEntity.bid"
        };

        string expected = "MyEntity";

        //Act
        IBidParser target = new BidParser();
        BidEntity actual = target.Parse(input);

        //Assert
        Assert.AreEqual(expected, actual.Name);
    }

    [TestMethod]
    public void Parse_With3Attributes_ReturnAttributes()
    {
        //Arrange
        File input = new()
        {
            Path = "MyEntity.bid",
            Contents = new StringBuilder()
                .AppendLine("Item1")
                .AppendLine("Item2")
                .AppendLine("Item3")
                .ToString()
        };

        BidEntity expected = new();
        expected.Attributes.AddRange(new string[] {"Item1", "Item2", "Item3"});

        //Act
        IBidParser target = new BidParser();
        BidEntity actual = target.Parse(input);

        //Assert
        Assert.AreEqual(expected.Attributes.Count, actual.Attributes.Count);
        Assert.AreEqual(expected.Entities.Count, actual.Entities.Count);
        Assert.AreEqual(expected.AttributeSets.Count, actual.AttributeSets.Count);
        Assert.AreEqual(expected.EntitySets.Count, actual.EntitySets.Count);
        Assert.AreEqual(expected.Attributes[0], actual.Attributes[0]);
        Assert.AreEqual(expected.Attributes[1], actual.Attributes[1]);
        Assert.AreEqual(expected.Attributes[2], actual.Attributes[2]);
    }

    [TestMethod]
    public void Parse_With3Entities_ReturnEntities()
    {
        //Arrange
        File input = new()
        {
            Path = "MyEntity.bid",
            Contents = new StringBuilder()
                .AppendLine("--")
                .AppendLine("Item1")
                .AppendLine("Item2")
                .AppendLine("Item3")
                .ToString()
        };

        BidEntity expected = new();
        expected.Entities.AddRange(new string[] {"Item1", "Item2", "Item3"});

        //Act
        IBidParser target = new BidParser();
        BidEntity actual = target.Parse(input);

        //Assert
        Assert.AreEqual(expected.Attributes.Count, actual.Attributes.Count);
        Assert.AreEqual(expected.Entities.Count, actual.Entities.Count);
        Assert.AreEqual(expected.AttributeSets.Count, actual.AttributeSets.Count);
        Assert.AreEqual(expected.EntitySets.Count, actual.EntitySets.Count);
        Assert.AreEqual(expected.Entities[0], actual.Entities[0]);
        Assert.AreEqual(expected.Entities[1], actual.Entities[1]);
        Assert.AreEqual(expected.Entities[2], actual.Entities[2]);
    }

    [TestMethod]
    public void Parse_With3AttributeSets_ReturnAttributeSets()
    {
        //Arrange
        File input = new()
        {
            Path = "MyEntity.bid",
            Contents = new StringBuilder()
                .AppendLine("--")
                .AppendLine("--")
                .AppendLine("Item1")
                .AppendLine("Item2")
                .AppendLine("Item3")
                .ToString()
        };

        BidEntity expected = new();
        expected.AttributeSets.AddRange(new string[] {"Item1", "Item2", "Item3"});

        //Act
        IBidParser target = new BidParser();
        BidEntity actual = target.Parse(input);

        //Assert
        Assert.AreEqual(expected.Attributes.Count, actual.Attributes.Count);
        Assert.AreEqual(expected.Entities.Count, actual.Entities.Count);
        Assert.AreEqual(expected.AttributeSets.Count, actual.AttributeSets.Count);
        Assert.AreEqual(expected.EntitySets.Count, actual.EntitySets.Count);
        Assert.AreEqual(expected.AttributeSets[0], actual.AttributeSets[0]);
        Assert.AreEqual(expected.AttributeSets[1], actual.AttributeSets[1]);
        Assert.AreEqual(expected.AttributeSets[2], actual.AttributeSets[2]);
    }

    [TestMethod]
    public void Parse_With3EntitySets_ReturnEntitySets()
    {
        //Arrange
        File input = new()
        {
            Path = "MyEntity.bid",
            Contents = new StringBuilder()
                .AppendLine("--")
                .AppendLine("--")
                .AppendLine("--")
                .AppendLine("Item1")
                .AppendLine("Item2")
                .AppendLine("Item3")
                .ToString()
        };

        BidEntity expected = new();
        expected.EntitySets.AddRange(new string[] {"Item1", "Item2", "Item3"});

        //Act
        IBidParser target = new BidParser();
        BidEntity actual = target.Parse(input);

        //Assert
        Assert.AreEqual(expected.Attributes.Count, actual.Attributes.Count);
        Assert.AreEqual(expected.Entities.Count, actual.Entities.Count);
        Assert.AreEqual(expected.AttributeSets.Count, actual.AttributeSets.Count);
        Assert.AreEqual(expected.EntitySets.Count, actual.EntitySets.Count);
        Assert.AreEqual(expected.EntitySets[0], actual.EntitySets[0]);
        Assert.AreEqual(expected.EntitySets[1], actual.EntitySets[1]);
        Assert.AreEqual(expected.EntitySets[2], actual.EntitySets[2]);
    }

    [TestMethod]
    public void Parse_WithSingleOfEach_ReturnAll()
    {
        //Arrange
        File input = new()
        {   
            Path = "MyEntity.bid",
            Contents = new StringBuilder()
                .AppendLine("Item1")
                .AppendLine("--")
                .AppendLine("Item2")
                .AppendLine("--")
                .AppendLine("Item3")
                .AppendLine("--")
                .AppendLine("Item4")
                .ToString()
        };

        BidEntity expected = new();
        expected.Attributes.Add("Item1");
        expected.Entities.Add("Item2");
        expected.AttributeSets.Add("Item3");
        expected.EntitySets.Add("Item4");

        //Act
        IBidParser target = new BidParser();
        BidEntity actual = target.Parse(input);

        //Assert
        Assert.AreEqual(expected.Attributes.Count, actual.Attributes.Count);
        Assert.AreEqual(expected.Entities.Count, actual.Entities.Count);
        Assert.AreEqual(expected.AttributeSets.Count, actual.AttributeSets.Count);
        Assert.AreEqual(expected.EntitySets.Count, actual.EntitySets.Count);
        Assert.AreEqual(expected.Attributes[0], actual.Attributes[0]);
        Assert.AreEqual(expected.Entities[0], actual.Entities[0]);
        Assert.AreEqual(expected.AttributeSets[0], actual.AttributeSets[0]);
        Assert.AreEqual(expected.EntitySets[0], actual.EntitySets[0]);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]  //Assert
    public void Parse_WithNullFile_ReturnException()
    {
        //Arrange
        File input = null;

        //Act
        IBidParser target = new BidParser();
        target.Parse(input);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]  //Assert
    public void Parse_WithMissingPath_ReturnException()
    {
        //Arrange
        File input = new() { Contents = "My Content" };

        //Act
        IBidParser target = new BidParser();
        target.Parse(input);
    }
}
