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

namespace JustTooFast.SampleXml.Tests;

[TestClass]
public class ElementDeclarationTest
{
    [TestMethod]
    public void Generate_WithName_ReturnWithName()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("test");
        
        string expected = "<test></test>";

        //Act
        ElementDeclaration target = new(builder);
        string actual = target.Generate();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Generate_WithText_ReturnWithText()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("myElement")
            .WithText("Hello, World!");
        
        string expected = "<myElement>Hello, World!</myElement>";

        //Act
        ElementDeclaration target = new(builder);
        string actual = target.Generate();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Generate_WithSingleAttribute_ReturnWithAttribute()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("myElement")
            .WithAttribute(x => x
                .WithName("myAttribute"));
        
        string expected = "<myElement myAttribute=\"\"></myElement>";

        //Act
        ElementDeclaration target = new(builder);
        string actual = target.Generate();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Generate_With2Attributes_ReturnWithAttributes()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("test")
            .WithAttribute(x => x
                .WithName("first"))
            .WithAttribute(x => x
                .WithName("second"));
        
        string expected = "<test first=\"\" second=\"\"></test>";

        //Act
        ElementDeclaration target = new(builder);
        string actual = target.Generate();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Generate_WithNestedElement_ReturnNestedElement()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("element")
            .WithElement(x => x
                .WithName("nestedElement"));
        
        string expected = new StringBuilder()
            .AppendLine("<element>")
            .AppendLine("  <nestedElement></nestedElement>")
            .Append("</element>")
            .ToString();

        //Act
        ElementDeclaration target = new(builder);
        string actual = target.Generate();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Generate_With2NestedElements_ReturnNestedElements()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("element")
            .WithElement(x => x
                .WithName("nestedElement1"))
            .WithElement(x => x
                .WithName("nestedElement2"));
        
        string expected = new StringBuilder()
            .AppendLine("<element>")
            .AppendLine("  <nestedElement1></nestedElement1>")
            .AppendLine("  <nestedElement2></nestedElement2>")
            .Append("</element>")
            .ToString();

        //Act
        ElementDeclaration target = new(builder);
        string actual = target.Generate();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Generate_WithNestedElementsInNestedElement_ReturnNestedElements()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("element")
            .WithElement(x => x
                .WithName("nestedElement1")
                .WithElement(y => y
                    .WithName("nestedElement2"))
                .WithElement(y => y
                    .WithName("nestedElement3")))
            .WithElement(x => x
                .WithName("nestedElement1")
                .WithElement(y => y
                    .WithName("nestedElement2"))
                .WithElement(y => y
                    .WithName("nestedElement3")));
        
        string expected = new StringBuilder()
            .AppendLine("<element>")
            .AppendLine("  <nestedElement1>")
            .AppendLine("    <nestedElement2></nestedElement2>")
            .AppendLine("    <nestedElement3></nestedElement3>")
            .AppendLine("  </nestedElement1>")
            .AppendLine("  <nestedElement1>")
            .AppendLine("    <nestedElement2></nestedElement2>")
            .AppendLine("    <nestedElement3></nestedElement3>")
            .AppendLine("  </nestedElement1>")
            .Append("</element>")
            .ToString();

        //Act
        ElementDeclaration target = new(builder);
        string actual = target.Generate();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]   //Assert
    public void Validate_MissingName_ThrowException()
    {
        //Arrange
        ElementBuilder builder = new();

        //Act
        ElementDeclaration target = new(builder);
    }
}
