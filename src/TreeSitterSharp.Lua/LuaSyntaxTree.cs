using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.Lua;
public unsafe class LuaSyntaxTree : SyntaxTree<LuaSyntaxNode, LuaSyntaxTree>, ISyntaxTreeCreation<LuaSyntaxNode, LuaSyntaxTree>
{
    protected internal LuaSyntaxTree(TsTree* tree) : base(tree)
    {
    }
    public override LuaSyntaxNode Root => new(Ts.tree_root_node(_tree));
    public override LuaSyntaxTree Copy() => new(Ts.tree_copy(_tree));
    public static LuaSyntaxTree Create(TsTree* tree) => new(tree);
}
