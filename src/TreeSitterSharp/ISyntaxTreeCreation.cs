using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public interface ISyntaxTreeCreation<TSyntaxNode, out TSelf>
    where TSelf : ISyntaxTree<TSyntaxNode, TSelf>
    where TSyntaxNode : ISyntaxNode<TSelf, TSyntaxNode>
{
    static abstract unsafe TSelf Create(TsTree* tree);
}
