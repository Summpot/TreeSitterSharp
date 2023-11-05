using System.Text;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public abstract unsafe class SyntaxTree<TSyntaxNode, TSelf> : ISyntaxTree<TSyntaxNode, TSelf>
    where TSelf : SyntaxTree<TSyntaxNode, TSelf>
    where TSyntaxNode : ISyntaxNode<TSelf, TSyntaxNode>
{
    protected readonly TsTree* _tree;

    protected internal SyntaxTree(TsTree* tree)
    {
        _tree = tree;
    }

    ~SyntaxTree()
    {
        Ts.tree_delete(_tree);
    }

    public abstract TSelf Copy();

    public Language Language => new(Ts.tree_language(_tree));

    public abstract TSyntaxNode Root { get; }
}
