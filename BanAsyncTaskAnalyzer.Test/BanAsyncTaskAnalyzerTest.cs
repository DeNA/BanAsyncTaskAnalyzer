// Copyright (c) 2020-2023 DeNA Co., Ltd.
// This software is released under the MIT License.

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dena.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BanAsyncTaskAnalyzer.Test;

/// <summary>
/// This test is an examples of using the Dena.CodeAnalysis.Testing test helper library.
/// <see href="https://github.com/DeNA/Dena.CodeAnalysis.Testing"/>
/// </summary>
[TestFixture]
public class BanAsyncTaskAnalyzerTest
{
    private static string[] ReadCodes(params string[] sources)
    {
        const string Path = "../../../TestData";
        return sources.Select(file => File.ReadAllText($"{Path}/{file}", Encoding.UTF8)).ToArray();
    }
}
