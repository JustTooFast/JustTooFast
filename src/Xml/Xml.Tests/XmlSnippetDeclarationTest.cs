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
public class XmlSnippetDeclarationTest
{
    [TestMethod]
    public void AppendDeclaration_WithElement_ReturnWithElement()
    {
        //Arrange
        XmlSnippetBuilder builder = new XmlSnippetBuilder()
            .WithElement(x => x
                .WithName("book"));
        
        string expected = "<book></book>";

        //Act
        XmlSnippetDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_With2Elements_ReturnWithElements()
    {
        //Arrange
        XmlSnippetBuilder builder = new XmlSnippetBuilder()
            .WithElement(x => x
                .WithName("book"))
            .WithElement(x => x
                .WithName("book"));
        
        string expected =
@"<book></book>
<book></book>";

        //Act
        XmlSnippetDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(XmlFormatException))]   //Assert
    public void Validate_MissingElement_ThrowException()
    {
        //Arrange
        XmlSnippetBuilder builder = new();

        //Act
        XmlSnippetDeclaration target = new(builder, new Appender());
    }
}