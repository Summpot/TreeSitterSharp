using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.C;
public class CSyntaxNode : SyntaxNode
{
    protected internal CSyntaxNode(TsNode node) : base(node)
    {
    }

    
}
