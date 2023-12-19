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
using System.Text;

namespace JustTooFast.BidFast.Tests;

[TestClass]
public class StringBuilderExTest
{
    [TestMethod]
    public void AppendLineFeed_NoString_AddLineFeed()
    {
        //Arrange
        StringBuilder target = new();
        string expected = "\n";

        //Act
        string actual = target.AppendLineFeed().ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AppendLineFeed_WithString_AddStringWithLineFeed()
    {
        //Arrange
        StringBuilder target = new();
        string expected = "test\n";

        //Act
        string actual = target.AppendLineFeed("test").ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))] //Assert
    public void AppendLineFeed_NoStringNullStringBuilder_ThrowException()
    {
        //Arrange
        StringBuilder target = null;

        //Act
        target.AppendLineFeed();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))] //Assert
    public void AppendLineFeed_WithStringNullStringBuilder_ThrowException()
    {
        //Arrange
        StringBuilder target = null;

        //Act
        target.AppendLineFeed("test");
    }
}