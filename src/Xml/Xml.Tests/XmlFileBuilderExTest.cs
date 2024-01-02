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
public class XmlFileBuilderExTest
{
    [TestMethod]
    public void Generate_WithRootElement_ReturnWithRootElement()
    {
        //Arrange
        XmlFileBuilder target = new XmlFileBuilder()
            .WithRootElement(x => x
                .WithName("catalog"));
        
        string expected =
@"<?xml version=""1.0""?>
<catalog></catalog>";

        //Act
        string actual = target.Generate();

        //Assert
        Assert.AreEqual(expected, actual);
    }
}
