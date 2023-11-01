using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class Tree
{
    private readonly TsTree* _tree;

    public Tree(TsTree* tree)
    {
        _tree = tree;
    }

    ~Tree()
    {
        Ts.tree_delete(_tree);
    }

    public Tree Copy() => new(Ts.tree_copy(_tree));

    public Language Language => new(Ts.tree_language(_tree));

    public Node Root => new(Ts.tree_root_node(_tree));
}
