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

using System.Text;

namespace JustTooFast.Xml;
public class Appender : IAppender
{
    private readonly StringBuilder m_StringBuilder = new();

    public void Append(string value)
    {
        m_StringBuilder.Append(value);
    }

    public void Append(char value)
    {
        m_StringBuilder.Append(value);
    }

    public void AppendLineFeed()
    {
        m_StringBuilder.Append('\n');
    }

    public void AppendLineFeed(string value)
    {
        m_StringBuilder.Append($"{value}\n");
    }

    public override string ToString()
    {
        return m_StringBuilder.ToString();
    }
}