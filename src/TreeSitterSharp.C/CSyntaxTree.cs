using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.C;
public unsafe class CSyntaxTree : SyntaxTree<CSyntaxNode, CSyntaxTree>, ISyntaxTreeCreation<CSyntaxNode, CSyntaxTree>
{
    protected internal CSyntaxTree(TsTree* tree) : base(tree)
    {
    }
    public TranslationUnit TranslationUnit => new(Ts.tree_root_node(_tree));
    public override CSyntaxNode Root => TranslationUnit;
    public override CSyntaxTree Copy() => new(Ts.tree_copy(_tree));
    public static CSyntaxTree Create(TsTree* tree) => new(tree);
}
