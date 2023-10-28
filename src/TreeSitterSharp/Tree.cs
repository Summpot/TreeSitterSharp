using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class Tree
{
    private readonly TsTree* _internalTree;

    ~Tree()
    {
        Ts.tree_delete(_internalTree);
    }
    public Tree(TsTree* tree)
    {
        _internalTree = tree;
    }

    public Language Language { get; }

    public Tree(TsTree* tree, Language language) : this(tree)
    {
        Language = language;
    }

    public Node Root => new(Ts.tree_root_node(_internalTree));
}
