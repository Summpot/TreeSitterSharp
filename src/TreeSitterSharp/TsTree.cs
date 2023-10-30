using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class TsTree
{
    private readonly Native.TsTree* _tree;

    public TsTree(Native.TsTree* tree)
    {
        _tree = tree;
    }

    ~TsTree()
    {
        Ts.tree_delete(_tree);
    }

    public TsTree Copy() => new(Ts.tree_copy(_tree));

    public TsLanguage Language => new(Ts.tree_language(_tree));

    public TsNode Root => new(Ts.tree_root_node(_tree));
}
