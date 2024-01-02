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
public class XmlFileGeneratorTest
{
    [TestMethod]
    public void Generate_WithRootElement_ReturnWithRootElement()
    {
        //Arrange
        XmlFileBuilder builder = new XmlFileBuilder()
            .WithRootElement(x => x
                .WithName("catalog")
                .WithElement(y => y
                    .WithName("book")
                    .WithAttribute(z => z
                        .WithName("id")
                        .WithValue("bk101"))
                    .WithElement(z => z
                        .WithName("author")
                        .WithText("Gambardella, Matthew"))
                    .WithElement(z => z
                        .WithName("title")
                        .WithText("XML Developer's Guide"))
                    .WithElement(z => z
                        .WithName("genre")
                        .WithText("Computer"))
                    .WithElement(z => z
                        .WithName("price")
                        .WithText("44.95"))
                    .WithElement(z => z
                        .WithName("publish_date")
                        .WithText("2000-10-01"))
                    .WithElement(z => z
                        .WithName("description")
                        .WithText("An in-depth look at creating applications with XML.")))
                .WithElement(y => y
                    .WithName("book")
                    .WithAttribute(z => z
                        .WithName("id")
                        .WithValue("bk110"))
                    .WithElement(z => z
                        .WithName("author")
                        .WithText("O'Brien, Tim"))
                    .WithElement(z => z
                        .WithName("title")
                        .WithText("Microsoft .NET: The Programming Bible"))
                    .WithElement(z => z
                        .WithName("genre")
                        .WithText("Computer"))
                    .WithElement(z => z
                        .WithName("price")
                        .WithText("36.95"))
                    .WithElement(z => z
                        .WithName("publish_date")
                        .WithText("2000-12-09"))
                    .WithElement(z => z
                        .WithName("description")
                        .WithText("Microsoft's .NET initiative is explored in detail in this deep programmer's reference."))));
        
        string expected =
@"<?xml version=""1.0""?>
<catalog>
  <book id=""bk101"">
    <author>Gambardella, Matthew</author>
    <title>XML Developer's Guide</title>
    <genre>Computer</genre>
    <price>44.95</price>
    <publish_date>2000-10-01</publish_date>
    <description>An in-depth look at creating applications with XML.</description>
  </book>
  <book id=""bk110"">
    <author>O'Brien, Tim</author>
    <title>Microsoft .NET: The Programming Bible</title>
    <genre>Computer</genre>
    <price>36.95</price>
    <publish_date>2000-12-09</publish_date>
    <description>Microsoft's .NET initiative is explored in detail in this deep programmer's reference.</description>
  </book>
</catalog>";

        //Act
        XmlFileGenerator target = builder;
        string actual = target.Generate();

        //Assert
        Assert.AreEqual(expected, actual);
    }
}