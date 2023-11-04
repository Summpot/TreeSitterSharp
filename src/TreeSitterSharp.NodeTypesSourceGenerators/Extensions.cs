using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace TreeSitterSharp.NodeTypesSourceGenerators;
internal static class Extensions
{

    public static T If<T>(this T syntaxNode, bool condition, Func<T, T> func) where T : SyntaxNode
    {
        return condition ? func(syntaxNode) : syntaxNode;
    }
}
