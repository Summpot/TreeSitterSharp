using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class Tree
{
    private TsTree* _internalTree;
    public static Tree FromNative(TsTree* tree)
    {
        return new Tree() { _internalTree = tree };
    }

    public Node Root => Node.FromNative(Ts.tree_root_node(_internalTree));
}
