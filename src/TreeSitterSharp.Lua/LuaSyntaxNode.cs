using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.Lua;

public partial class LuaSyntaxNode : SyntaxNode<LuaSyntaxTree, LuaSyntaxNode>, ISyntaxNodeCreation<LuaSyntaxTree, LuaSyntaxNode>
{
    protected internal LuaSyntaxNode(TsNode node) : base(node)
    {
    }


    public static partial LuaSyntaxNode Create(TsNode node);
}
