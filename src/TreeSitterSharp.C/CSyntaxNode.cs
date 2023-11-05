using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.C;

public partial class CSyntaxNode : SyntaxNode<CSyntaxTree, CSyntaxNode>, ISyntaxNodeCreation<CSyntaxTree, CSyntaxNode>
{
    protected internal CSyntaxNode(TsNode node) : base(node)
    {
    }


    public static partial CSyntaxNode Create(TsNode node);
}
