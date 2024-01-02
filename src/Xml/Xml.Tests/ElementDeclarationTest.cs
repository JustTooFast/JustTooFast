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

namespace JustTooFast.Xml.Tests;

[TestClass]
public class ElementDeclarationTest
{
    [TestMethod]
    public void AppendDeclaration_WithName_ReturnWithName()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("book");
        
        string expected = "<book></book>";

        //Act
        ElementDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_WithText_ReturnWithText()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("price")
            .WithText("44.95");
        
        string expected = "<price>44.95</price>";

        //Act
        ElementDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_WithSingleAttribute_ReturnWithAttribute()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("book")
            .WithAttribute(x => x
                .WithName("id"));
        
        string expected = "<book id=\"\"></book>";

        //Act
        ElementDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_With2Attributes_ReturnWithAttributes()
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
        ElementDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_WithChildElement_ReturnChildElement()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("book")
            .WithElement(x => x
                .WithName("title"));
        
        string expected =
@"<book>
  <title></title>
</book>";

        //Act
        ElementDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_With2ChildElements_ReturnChildElements()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("book")
            .WithElement(x => x
                .WithName("author"))
            .WithElement(x => x
                .WithName("title"));
        
        string expected =
@"<book>
  <author></author>
  <title></title>
</book>";

        //Act
        ElementDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_WithNestedChildElements_ReturnChildElements()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("catalog")
            .WithElement(x => x
                .WithName("book")
                .WithElement(y => y
                    .WithName("author"))
                .WithElement(y => y
                    .WithName("title")))
            .WithElement(x => x
                .WithName("book")
                .WithElement(y => y
                    .WithName("author"))
                .WithElement(y => y
                    .WithName("title")));
        
        string expected =
@"<catalog>
  <book>
    <author></author>
    <title></title>
  </book>
  <book>
    <author></author>
    <title></title>
  </book>
</catalog>";

        //Act
        ElementDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(XmlFormatException))]   //Assert
    public void Validate_MissingName_ThrowException()
    {
        //Arrange
        ElementBuilder builder = new();

        //Act
        ElementDeclaration target = new(builder, new Appender());
    }

    [TestMethod]
    [ExpectedException(typeof(XmlFormatException))]   //Assert
    public void Validate_BothTextAndElement_ThrowException()
    {
        //Arrange
        ElementBuilder builder = new ElementBuilder()
            .WithName("book")
            .WithText("XML Developer's Guide")
            .WithElement(x => x
                .WithName("title"));

        //Act
        ElementDeclaration target = new(builder, new Appender());
    }
}