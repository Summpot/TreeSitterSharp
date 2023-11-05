using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace TreeSitterSharp.NodeTypesSourceGenerators;
internal static class Extensions
{
    public static T? GetConstructorArgument<T>(this AttributeData attribute, int index)
    {
        if (TryGetConstructorArgument<T>(attribute, index, out var result))
        {
            return result;
        }
        return default;
    }

    public static bool TryGetConstructorArgument<T>(this AttributeData attribute, int index, out T? result)
    {
        if (index < attribute.ConstructorArguments.Length)
        {
            if (attribute.ConstructorArguments.ElementAtOrDefault(index).Value is T o)
            {
                result = o;
                return true;
            }
        }
        result = default;
        return false;

    }
    public static T If<T>(this T syntaxNode, bool condition, Func<T, T> func) where T : SyntaxNode
    {
        return condition ? func(syntaxNode) : syntaxNode;
    }
}
