using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.Json;
public class JsonSyntaxNode : SyntaxNode<JsonSyntaxTree, JsonSyntaxNode>, ISyntaxNodeCreation<JsonSyntaxTree, JsonSyntaxNode>
{
    protected internal JsonSyntaxNode(TsNode node) : base(node)
    {
    }

    public static JsonSyntaxNode Create(TsNode node) => new(node);
}
