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

namespace JustTooFast.BidFast;
internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Missing arguments. Please include inputFolder outputFolder targetNamespace arguments.");
        }
        else
        {
            Console.Write("Generating file(s)...");

            IFileHelper fileHelper = new FileHelper();
            IBidParser bidParser = new BidParser();

            string inputFolder = args[1];
            string outputFolder = args[2];
            string targetNamespace = args[3];

            IBidWriter bidWriter = new BidWriter(fileHelper, bidParser);
            int result = bidWriter.Write(inputFolder, outputFolder, targetNamespace);

            Console.WriteLine($"{result} file(s) generated.");
        }
    }
}