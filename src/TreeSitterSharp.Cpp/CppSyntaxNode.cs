using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.Cpp;

public partial class CppSyntaxNode : SyntaxNode<CppSyntaxTree, CppSyntaxNode>, ISyntaxNodeCreation<CppSyntaxTree, CppSyntaxNode>
{
    protected internal CppSyntaxNode(TsNode node) : base(node)
    {
    }


    public static partial CppSyntaxNode Create(TsNode node);
}
