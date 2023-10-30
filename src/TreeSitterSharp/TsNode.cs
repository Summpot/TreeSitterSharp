using System.Diagnostics;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public unsafe class TsNode
{
    private readonly Native.TsNode _node;

    internal TsNode(Native.TsNode node)
    {
        _node = node;
        Tree = new TsTree(_node.tree);
    }

    public TsTree Tree { get; }
    public nint Id => (nint)_node.id;
    public string Type => Ts.node_type(_node);
    public ushort Symbol => Ts.node_symbol(_node);
    public TsLanguage Language => new(Ts.node_language(_node));
    public string GrammarType => Ts.node_grammar_type(_node);
    public ushort GrammarSymbol => Ts.node_grammar_symbol(_node);
    public uint StartByte => Ts.node_start_byte(_node);
    public uint EndByte => Ts.node_end_byte(_node);
    public TsPoint StartPoint => Ts.node_start_point(_node);
    public TsPoint EndPoint => Ts.node_end_point(_node);
    public uint ChildCount => Ts.node_child_count(_node);
    public uint NamedChildCount => Ts.node_named_child_count(_node);
    public TsNode? PreviousSibling
    {
        get
        {
            var node = Ts.node_prev_sibling(_node);
            return Ts.node_is_null(node) ? null : new(node);
        }
    }

    public TsNode? NextSibling
    {
        get
        {
            var node = Ts.node_next_sibling(_node);
            return Ts.node_is_null(node) ? null : new(node);
        }
    }

    public TsNode? PreviousNamedSibling
    {
        get
        {
            var node = Ts.node_prev_named_sibling(_node);
            return Ts.node_is_null(node) ? null : new(node);
        }
    }

    public TsNode? NextNamedSibling
    {
        get
        {
            var node = Ts.node_next_named_sibling(_node);
            return Ts.node_is_null(node) ? null : new(node);
        }
    }

    public TsNode? Parent
    {
        get
        {
            var node = Ts.node_parent(_node);
            return Ts.node_is_null(node) ? null : new(node);
        }
    }

    public bool IsNamed => Ts.node_is_named(_node);
    public bool IsMissing => Ts.node_is_missing(_node);
    public bool IsExtra => Ts.node_is_extra(_node);
    public bool IsNull => Ts.node_is_null(_node);

    public TsNode GetChildByFieldName(string fieldName)
    {
        return new TsNode(Ts.node_child_by_field_name(_node, fieldName, (uint)fieldName.Length));
    }

    public TsNode GetChildByFieldId(ushort fieldId) => new(Ts.node_child_by_field_id(_node, fieldId));

    public string GetFieldNameForChild(uint childIndex) => Ts.node_field_name_for_child(_node, childIndex);

    public TsNode GetNamedChild(uint index)
    {
        return new TsNode(Ts.node_named_child(_node, index));
    }

    public IEnumerable<TsNode> GetNamedChildren()
    {
        for (uint i = 0; i < NamedChildCount; i++)
        {
            yield return GetNamedChild(i);
        }
    }

    public IEnumerable<TsNode> GetChildren()
    {
        for (uint i = 0; i < ChildCount; i++)
        {
            yield return GetChild(i);
        }
    }

    public TsNode GetChild(uint index)
    {
        return new TsNode(Ts.node_child(_node, index));
    }

    public Native.TsNode ToUnmanaged()
    {
        return _node;
    }

    public string GetSExpression()
    {
        return Ts.node_string(_node);
    }

    protected bool Equals(TsNode other) => Ts.node_eq(_node, other._node);

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

        return Equals((TsNode)obj);
    }

    public override int GetHashCode() => _node.GetHashCode();
}
