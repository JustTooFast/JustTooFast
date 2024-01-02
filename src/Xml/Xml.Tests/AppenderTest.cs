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
public class AppenderTest
{
    [TestMethod]
    public void Append_WithString_ReturnString()
    {
        //Arrange
        IAppender target = new Appender();
        string expected = "test";

        //Act
        target.Append(expected);
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Append_WithChar_ReturnChar()
    {
        //Arrange
        IAppender target = new Appender();
        char expected = 'A';

        //Act
        target.Append(expected);
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected.ToString(), actual);
    }

    [TestMethod]
    public void AppendLineFeed_NoArgs_ReturnLineFeed()
    {
        //Arrange
        IAppender target = new Appender();
        string expected = "\n";

        //Act
        target.AppendLineFeed();
        string actual = target.ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendLineFeed_WithString_ReturnStringAndLineFeed()
    {
        //Arrange
        IAppender target = new Appender();
        string expected = "test";

        //Act
        target.AppendLineFeed(expected);
        string actual = target.ToString();

        //Assert
        Assert.AreEqual($"{expected}\n", actual);
    }
}
