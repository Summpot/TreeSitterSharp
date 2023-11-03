using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class TreeSitterSyntaxTree
{
    private readonly TsTree* _tree;

    public TreeSitterSyntaxTree(TsTree* tree)
    {
        _tree = tree;
    }

    ~TreeSitterSyntaxTree()
    {
        Ts.tree_delete(_tree);
    }

    public TreeSitterSyntaxTree Copy() => new(Ts.tree_copy(_tree));

    public Language Language => new(Ts.tree_language(_tree));

    public TreeSitterSyntaxNode Root => new(Ts.tree_root_node(_tree));
}
