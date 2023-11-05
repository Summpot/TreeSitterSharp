using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public interface ISyntaxNodeCreation<out TSyntaxTree, out TSelf>
    where TSelf : ISyntaxNode<TSyntaxTree, TSelf>
    where TSyntaxTree : ISyntaxTree<TSelf, TSyntaxTree>
{
    static abstract TSelf Create(TsNode node);
}
