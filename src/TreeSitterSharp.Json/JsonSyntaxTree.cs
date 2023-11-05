using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.Json;
public class JsonSyntaxTree : SyntaxTree<JsonSyntaxNode, JsonSyntaxTree>, ISyntaxTreeCreation<JsonSyntaxNode, JsonSyntaxTree>
{
    internal unsafe JsonSyntaxTree(TsTree* tree) : base(tree)
    {
    }

    public override JsonSyntaxTree Copy()
    {
        unsafe
        {
            return new(Ts.tree_copy(_tree));
        }
    }

    public override JsonSyntaxNode Root { get; }
    public static unsafe JsonSyntaxTree Create(TsTree* tree) => new(tree);
}
