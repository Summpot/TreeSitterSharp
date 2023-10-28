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
    private readonly TsNode _node;

    internal Node(TsNode node)
    {
        _node = node;
        Tree = new Tree(_node.tree);
    }

    public Tree Tree { get; }
    public string Type => Ts.node_type(_node);
    public uint ChildCount => Ts.node_child_count(_node);
    public uint NamedChildCount => Ts.node_named_child_count(_node);
    public Node PreviousSibling => new(Ts.node_prev_sibling(_node));
    public Node NextSibling => new(Ts.node_next_sibling(_node));
    public Node PreviousNamedSibling => new(Ts.node_prev_named_sibling(_node));
    public Node NextNamedSibling => new(Ts.node_next_named_sibling(_node));
    public Node Parent => new(Ts.node_parent(_node));
    public bool IsNull => Ts.node_is_null(_node);
    public bool IsNamed => Ts.node_is_named(_node);
    public bool IsMissing => Ts.node_is_missing(_node);
    public bool IsExtra => Ts.node_is_extra(_node);

    public Node GetNamedChild(uint index)
    {
        return new Node(Ts.node_named_child(_node, index));
    }

    public IEnumerable<Node> GetNamedChildren()
    {
        for (uint i = 0; i < NamedChildCount; i++)
        {
            yield return GetNamedChild(i);
        }
    }

    public IEnumerable<Node> GetChildren()
    {
        for (uint i = 0; i < ChildCount; i++)
        {
            yield return GetChild(i);
        }
    }

    public Node GetChildByFieldName(string fieldName)
    {
        return new Node(Ts.node_child_by_field_name(_node, fieldName, (uint)fieldName.Length));
    }

    public Node GetChild(uint index)
    {
        return new Node(Ts.node_child(_node, index));
    }

    public TsNode ToUnmanaged()
    {
        return _node;
    }

    public string GetSExpression()
    {
        return Ts.node_string(_node);
    }
}
