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

    public readonly string Type => Ts.node_type(_internalNode);
    public readonly uint ChildCount => Ts.node_child_count(_internalNode);
    public readonly uint NamedChildCount => Ts.node_named_child_count(_internalNode);
    public readonly Node PreviousSibling => FromUnmanaged(Ts.node_prev_sibling(_internalNode));
    public readonly Node NextSibling => FromUnmanaged(Ts.node_next_sibling(_internalNode));
    public readonly Node PreviousNamedSibling => FromUnmanaged(Ts.node_prev_named_sibling(_internalNode));
    public readonly Node NextNamedSibling => FromUnmanaged(Ts.node_next_named_sibling(_internalNode));
    public readonly Node Parent => FromUnmanaged(Ts.node_parent(_internalNode));
    public readonly bool IsNull => Ts.node_is_null(_internalNode);
    public readonly bool IsNamed => Ts.node_is_named(_internalNode);

    public readonly Node GetNamedChild(uint index)
    {
        return FromUnmanaged(Ts.node_named_child(_internalNode, index));
    }

    public readonly Node GetChildByFieldName(string fieldName)
    {
        return FromUnmanaged(Ts.node_child_by_field_name(_internalNode, fieldName, (uint)fieldName.Length));
    }

    public readonly Node GetChild(uint index)
    {
        return FromUnmanaged(Ts.node_child(_internalNode, index));
    }

    public static Node FromUnmanaged(TsNode node)
    {
        return new Node() { _internalNode = node };
    }

    public readonly TsNode ToUnmanaged()
    {
        return _internalNode;
    }

    public override readonly string ToString() => Ts.node_string(_internalNode);
}
