using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class Node
{
    private readonly TsNode _node;

    internal Node(TsNode node)
    {
        _node = node;
        Tree = new Tree(_node.tree);
    }

    public Tree Tree { get; }
    public string Type => IsNull() ? "null" : Ts.node_type(_node);
    public uint ChildCount => IsNull() ? 0 : Ts.node_child_count(_node);
    public uint NamedChildCount => IsNull() ? 0 : Ts.node_named_child_count(_node);
    public Node? PreviousSibling
    {
        get
        {
            var node = new Node(Ts.node_prev_sibling(_node));
            return node.IsNull() ? null : node;
        }
    }

    public Node? NextSibling
    {
        get
        {
            var node = new Node(Ts.node_next_sibling(_node));
            return node.IsNull() ? null : node;
        }
    }

    public Node? PreviousNamedSibling
    {
        get
        {
            var node = new Node(Ts.node_prev_named_sibling(_node));
            return node.IsNull() ? null : node;
        }
    }

    public Node? NextNamedSibling
    {
        get
        {
            var node = new Node(Ts.node_next_named_sibling(_node));
            return node.IsNull() ? null : node;
        }
    }

    public Node? Parent
    {
        get
        {
            var node = new Node(Ts.node_parent(_node));
            return node.IsNull() ? null : node;
        }
    }

    public bool IsNamed => !IsNull() && Ts.node_is_named(_node);
    public bool IsMissing => !IsNull() && Ts.node_is_missing(_node);
    public bool IsExtra => !IsNull() && Ts.node_is_extra(_node);

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

    private bool IsNull()
    {
        return Ts.node_is_null(_node);
    }

    protected bool Equals(Node other) => Ts.node_eq(_node, other._node);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != this.GetType())
        {
            return false;
        }

        return Equals((Node)obj);
    }

    public override int GetHashCode() => _node.GetHashCode();
}
