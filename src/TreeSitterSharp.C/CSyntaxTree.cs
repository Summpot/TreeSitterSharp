using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.C;
public unsafe class CSyntaxTree : SyntaxTree
{
    protected internal CSyntaxTree(TsTree* tree) : base(tree)
    {
    }
    public TranslationUnit TranslationUnit => new(Ts.tree_root_node(_tree));
    public override SyntaxNode Root => TranslationUnit;
}
