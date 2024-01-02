// Copyright 2024 Matthew Yancer
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
public class PrologDeclarationTest
{
    [TestMethod]
    public void AppendDeclaration_WithDefaultXml_ReturnXml()
    {
        //Arrange
        PrologBuilder builder = new();
        
        string expected = "<?xml version=\"1.0\"?>";

        //Act
        PrologDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendDeclaration_WithXmlEncoding_ReturnXmlEncoding()
    {
        //Arrange
        PrologBuilder builder = new PrologBuilder()
            .WithXml(x => x
                .WithEncoding(Encoding.UTF_8));
        
        string expected = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

        //Act
        PrologDeclaration target = new(builder, new Appender());
        target.AppendDeclaration();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }
}
