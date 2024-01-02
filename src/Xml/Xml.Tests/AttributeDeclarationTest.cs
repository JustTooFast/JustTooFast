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

namespace JustTooFast.Xml.Tests;

[TestClass]
public class AttributeDeclarationTest
{
    [TestMethod]
    public void AppendDeclaration_WithName_ReturnNameAndEmptyValue()
    {
        //Arrange
        AttributeBuilder builder = new AttributeBuilder()
            .WithName("id");
        
        string expected = "id=\"\"";

        //Act
        AttributeDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_WithNameAndValue_ReturnNameAndValue()
    {
        //Arrange
        AttributeBuilder builder = new AttributeBuilder()
            .WithName("id")
            .WithValue("bk101");
        
        string expected = "id=\"bk101\"";

        //Act
        AttributeDeclaration target = new(builder, new Appender());
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
        AttributeBuilder builder = new();

        //Act
        AttributeDeclaration target = new(builder, new Appender());
    }
}
