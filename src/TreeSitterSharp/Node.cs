using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe struct Node
{
    private TsNode _internalNode;

    internal Node(TsNode internalNode) => _internalNode = internalNode;

    public readonly string Type => Ts.node_type(_internalNode);
    public readonly uint ChildCount => Ts.node_child_count(_internalNode);
    public readonly uint NamedChildCount => Ts.node_named_child_count(_internalNode);
    public readonly Node PreviousSibling => new(Ts.node_prev_sibling(_internalNode));
    public readonly Node NextSibling => new(Ts.node_next_sibling(_internalNode));
    public readonly Node PreviousNamedSibling => new(Ts.node_prev_named_sibling(_internalNode));
    public readonly Node NextNamedSibling => new(Ts.node_next_named_sibling(_internalNode));
    public readonly Node Parent => new(Ts.node_parent(_internalNode));
    public readonly bool IsNull => Ts.node_is_null(_internalNode);
    public readonly bool IsNamed => Ts.node_is_named(_internalNode);
    public readonly bool IsMissing => Ts.node_is_missing(_internalNode);
    public readonly bool IsExtra => Ts.node_is_extra(_internalNode);

    public readonly Node GetNamedChild(uint index)
    {
        return new Node(Ts.node_named_child(_internalNode, index));
    }

    public readonly IEnumerable<Node> GetNamedChildren()
    {
        for (uint i = 0; i < NamedChildCount; i++)
        {
            yield return GetNamedChild(i);
        }
    }

    public readonly IEnumerable<Node> GetChildren()
    {
        for (uint i = 0; i < ChildCount; i++)
        {
            yield return GetChild(i);
        }
    }

    public readonly Node GetChildByFieldName(string fieldName)
    {
        return new Node(Ts.node_child_by_field_name(_internalNode, fieldName, (uint)fieldName.Length));
    }

    public readonly Node GetChild(uint index)
    {
        return new Node(Ts.node_child(_internalNode, index));
    }

    public readonly TsNode ToUnmanaged()
    {
        return _internalNode;
    }

    public override readonly string ToString() => Ts.node_string(_internalNode);
}
