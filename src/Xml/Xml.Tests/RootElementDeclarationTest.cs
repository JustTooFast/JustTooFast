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
public class RootElementDeclarationTest
{
    [TestMethod]
    public void AppendDeclaration_WithName_ReturnWithName()
    {
        //Arrange
        RootElementBuilder builder = new RootElementBuilder()
            .WithName("rootElement");
        
        string expected = "<rootElement></rootElement>";

        //Act
        RootElementDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_WithSingleAttribute_ReturnWithAttribute()
    {
        //Arrange
        RootElementBuilder builder = new RootElementBuilder()
            .WithName("rootElement")
            .WithAttribute(x => x
                .WithName("myAttribute"));
        
        string expected = "<rootElement myAttribute=\"\"></rootElement>";

        //Act
        RootElementDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_With2Attributes_ReturnWithAttributes()
    {
        //Arrange
        RootElementBuilder builder = new RootElementBuilder()
            .WithName("rootElement")
            .WithAttribute(x => x
                .WithName("first"))
            .WithAttribute(x => x
                .WithName("second"));
        
        string expected = "<rootElement first=\"\" second=\"\"></rootElement>";

        //Act
        RootElementDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_WithChildElement_ReturnChildElement()
    {
        //Arrange
        RootElementBuilder builder = new RootElementBuilder()
            .WithName("catalog")
            .WithElement(x => x
                .WithName("book"));
        
        string expected =
@"<catalog>
  <book></book>
</catalog>";

        //Act
        RootElementDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_With2ChildElements_ReturnChildElements()
    {
        //Arrange
        RootElementBuilder builder = new RootElementBuilder()
            .WithName("catalog")
            .WithElement(x => x
                .WithName("book"))
            .WithElement(x => x
                .WithName("book"));
        
        string expected =
@"<catalog>
  <book></book>
  <book></book>
</catalog>";

        //Act
        RootElementDeclaration target = new(builder, new Appender());
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
        RootElementBuilder builder = new();

        //Act
        RootElementDeclaration target = new(builder, new Appender());
    }
}