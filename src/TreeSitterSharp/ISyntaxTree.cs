using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public interface ISyntaxTree<TSyntaxNode, out TSelf>
    where TSelf : ISyntaxTree<TSyntaxNode, TSelf>
    where TSyntaxNode : ISyntaxNode<TSelf, TSyntaxNode>
{
    TSelf Copy();
}
