using System.Text;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class SyntaxTree
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

    public SyntaxTree Copy() => new(Ts.tree_copy(_tree));

    public Language Language => new(Ts.tree_language(_tree));

    public virtual SyntaxNode Root => new(Ts.tree_root_node(_tree));
}
