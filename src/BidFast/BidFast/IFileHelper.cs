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

namespace JustTooFast.BidFast;

/// <summary>
/// Contract for file handling routines.
/// </summary>
public interface IFileHelper
{
    /// <summary>
    /// Gets a list of files (with full path)
    /// from a given folder.
    /// </summary>
    /// <param name="folderPath">The folder to get a list of files from.</param>
    /// <returns>The list of files (with full path).</returns>
    string[] GetFilesInFolder(string folderPath);

    /// <summary>
    /// Reads a given file into a <see cref="File"/> object.
    /// </summary>
    /// <param name="filePath">The full path to the file.</param>
    /// <returns>The resulting <see cref="File"/> object.</returns>
    File Read(string filePath);

    /// <summary>
    /// Writes specified file contents to a given file.
    /// </summary>
    /// <param name="filePath">The full path to the file.</param>
    /// <param name="fileContents">The file contents to write.</param>
    void Write(string filePath, string fileContents);
}
