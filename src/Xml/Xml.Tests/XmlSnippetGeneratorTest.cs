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
public class XmlSnippetGeneratorTest
{
    [TestMethod]
    public void Generate_WithElements_ReturnWithElements()
    {
        //Arrange
        XmlSnippetBuilder builder = new XmlSnippetBuilder()
            .WithElement(x => x
                .WithName("book")
                .WithAttribute(y => y
                    .WithName("id")
                    .WithValue("bk101"))
                .WithElement(y => y
                    .WithName("author")
                    .WithText("Gambardella, Matthew"))
                .WithElement(y => y
                    .WithName("title")
                    .WithText("XML Developer's Guide"))
                .WithElement(y => y
                    .WithName("genre")
                    .WithText("Computer"))
                .WithElement(y => y
                    .WithName("price")
                    .WithText("44.95"))
                .WithElement(y => y
                    .WithName("publish_date")
                    .WithText("2000-10-01"))
                .WithElement(y => y
                    .WithName("description")
                    .WithText("An in-depth look at creating applications with XML.")))
            .WithElement(x => x
                .WithName("book")
                .WithAttribute(y => y
                    .WithName("id")
                    .WithValue("bk110"))
                .WithElement(y => y
                    .WithName("author")
                    .WithText("O'Brien, Tim"))
                .WithElement(y => y
                    .WithName("title")
                    .WithText("Microsoft .NET: The Programming Bible"))
                .WithElement(y => y
                    .WithName("genre")
                    .WithText("Computer"))
                .WithElement(y => y
                    .WithName("price")
                    .WithText("36.95"))
                .WithElement(y => y
                    .WithName("publish_date")
                    .WithText("2000-12-09"))
                .WithElement(y => y
                    .WithName("description")
                    .WithText("Microsoft's .NET initiative is explored in detail in this deep programmer's reference.")));
        
        string expected =
@"<book id=""bk101"">
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
</book>";

        //Act
        XmlSnippetGenerator target = builder;
        string actual = target.Generate();

        //Assert
        Assert.AreEqual(expected, actual);
    }
}