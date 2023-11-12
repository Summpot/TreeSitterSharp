using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.Cpp;
public unsafe class CppSyntaxTree : SyntaxTree<CppSyntaxNode, CppSyntaxTree>, ISyntaxTreeCreation<CppSyntaxNode, CppSyntaxTree>
{
    protected internal CppSyntaxTree(TsTree* tree) : base(tree)
    {
    }
    public override CppSyntaxNode Root => new(Ts.tree_root_node(_tree));
    public override CppSyntaxTree Copy() => new(Ts.tree_copy(_tree));
    public static CppSyntaxTree Create(TsTree* tree) => new(tree);
}
