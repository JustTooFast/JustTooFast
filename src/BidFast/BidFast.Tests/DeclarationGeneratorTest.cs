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

namespace JustTooFast.BidFast.Tests;

[TestClass]
public class DeclarationGeneratorTest
{
    [TestMethod]
    public void Generate_WithBasicStructure_ReturnStructure()
    {
        //Arrange
        BidEntity entity = new() { Name = "Test" };
        string targetNamespace = "MyNamespace";

        string expected =
@"using System;

namespace MyNamespace;
public partial class TestDeclaration
{
    private readonly TestInfo m_Test;

    public TestDeclaration(TestInfo test)
    {
        m_Test = test ?? throw new ArgumentNullException(nameof(test));
    }

    public partial string Generate();
}
";

        //Act
        IGenerator target = new DeclarationGenerator(entity, targetNamespace);
        string actual = target.Generate();

        //Assert
        Assert.AreEqual(expected, actual);
    }
}
