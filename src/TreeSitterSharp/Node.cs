using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe struct Node
{
    private TsNode _internalNode;

    public string Type => Ts.node_type(_internalNode);
    public uint ChildCount => Ts.node_child_count(_internalNode);
    public uint NamedChildCount => Ts.node_named_child_count(_internalNode);

    public Node GetNamedChild(uint index)
    {
        return FromNative(Ts.node_named_child(_internalNode, index));
    }

    public Node GetChild(uint index)
    {
        return FromNative(Ts.node_child(_internalNode, index));
    }

    public static Node FromNative(TsNode node)
    {
        return new Node() { _internalNode = node };
    }

    public TsNode ToUnmanaged()
    {
        return _internalNode;
    }

    public override string ToString() => Ts.node_string(_internalNode);
}
