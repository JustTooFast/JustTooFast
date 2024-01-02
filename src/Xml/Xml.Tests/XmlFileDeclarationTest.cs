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
public class XmlFileDeclarationTest
{
    [TestMethod]
    public void AppendDeclaration_WithRootElement_ReturnWithRootElement()
    {
        //Arrange
        XmlFileBuilder builder = new XmlFileBuilder()
            .WithRootElement(x => x
                .WithName("catalog"));
        
        string expected =
@"<?xml version=""1.0""?>
<catalog></catalog>";

        //Act
        XmlFileDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_WithPrologXmlEncoding_ReturnWithPrologXmlEncoding()
    {
        //Arrange
        XmlFileBuilder builder = new XmlFileBuilder()
            .WithProlog(x => x
                .WithXml(y => y
                    .WithEncoding(Encoding.UTF_8)))
            .WithRootElement(x => x
                .WithName("catalog"));
        
        string expected =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
<catalog></catalog>";

        //Act
        XmlFileDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_WithDisableProlog_ReturnWithoutProlog()
    {
        //Arrange
        XmlFileBuilder builder1 = new XmlFileBuilder()
            .WithDisableProlog(true)
            .WithRootElement(x => x
                .WithName("catalog"));
        
        XmlFileBuilder builder2 = new XmlFileBuilder()
            .AsDisableProlog()
            .WithRootElement(x => x
                .WithName("catalog"));
        
        string expected = "<catalog></catalog>";

        //Act
        XmlFileDeclaration target1 = new(builder1, new Appender());
        target1.AppendDeclaration();
        string actual1 = target1.ToString();

        XmlFileDeclaration target2 = new(builder2, new Appender());
        target2.AppendDeclaration();
        string actual2 = target2.ToString();

        //Assert
        Assert.AreEqual(expected, actual1);
        Assert.AreEqual(expected, actual2);
    }

    [TestMethod]
    [ExpectedException(typeof(XmlFormatException))]   //Assert
    public void Validate_MissingRootElement_ThrowException()
    {
        //Arrange
        XmlFileBuilder builder = new();

        //Act
        XmlFileDeclaration target = new(builder, new Appender());
    }
}