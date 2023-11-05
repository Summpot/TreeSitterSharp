using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSitterSharp;
public interface IParser<out TSyntaxTree, TSyntaxNode, TSelf>
    where TSelf : IParser<TSyntaxTree, TSyntaxNode, TSelf>
    where TSyntaxTree : ISyntaxTree<TSyntaxNode, TSyntaxTree>
    where TSyntaxNode : ISyntaxNode<TSyntaxTree, TSyntaxNode>
{
    TSyntaxTree Parse(Span<byte> code);
}
