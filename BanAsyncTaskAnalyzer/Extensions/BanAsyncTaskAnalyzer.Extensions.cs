// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace BanAsyncTaskAnalyzer.Extensions;

public static class NamespaceOrTypeSymbolExtensions
{
    public static string FullName(this INamespaceOrTypeSymbol symbol)
    {
        var collectedNamespace = new List<string>();
        while (symbol.Name != "")
        {
            collectedNamespace.Add(symbol.Name);
            symbol = symbol.ContainingNamespace;
        }

        collectedNamespace.Reverse();
        return string.Join(".", collectedNamespace);
    }
}