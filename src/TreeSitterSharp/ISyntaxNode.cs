using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public interface ISyntaxNode<out TSyntaxTree, out TSelf>
    where TSelf : ISyntaxNode<TSyntaxTree, TSelf>
    where TSyntaxTree : ISyntaxTree<TSelf, TSyntaxTree>
{
    TSyntaxTree Tree { get; }

    
}
