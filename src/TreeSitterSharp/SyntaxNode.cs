using System.Collections.Immutable;
using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public abstract unsafe class SyntaxNode<TSyntaxTree, TSelf> : ISyntaxNode<TSyntaxTree, TSelf>
    where TSelf : SyntaxNode<TSyntaxTree, TSelf>, ISyntaxNodeCreation<TSyntaxTree, TSelf>
    where TSyntaxTree : SyntaxTree<TSelf, TSyntaxTree>, ISyntaxTreeCreation<TSelf, TSyntaxTree>
{
    protected readonly TsNode _node;

    protected internal SyntaxNode(TsNode node)
    {
        _node = node;
        Tree = TSyntaxTree.Create(_node.tree);
    }

    public TSyntaxTree Tree { get; }

    public nint Id => (nint)_node.id;

    public string NodeType => Ts.node_type(_node);

    public ushort NodeSymbol => Ts.node_symbol(_node);

    public Language Language => new(Ts.node_language(_node));
    public virtual string GrammarType => Ts.node_grammar_type(_node);
    public ushort GrammarSymbol => Ts.node_grammar_symbol(_node);
    public uint StartByte => Ts.node_start_byte(_node);
    public uint EndByte => Ts.node_end_byte(_node);
    public Point StartPoint => Ts.node_start_point(_node);
    public Point EndPoint => Ts.node_end_point(_node);
    public uint ChildCount => Ts.node_child_count(_node);
    public uint NamedChildCount => Ts.node_named_child_count(_node);
    public TSelf? PreviousSibling
    {
        get
        {
            var node = Ts.node_prev_sibling(_node);
            return Ts.node_is_null(node) ? null : TSelf.Create(node);
        }
    }

    public TSelf? NextSibling
    {
        get
        {
            var node = Ts.node_next_sibling(_node);
            return Ts.node_is_null(node) ? null : TSelf.Create(node);
        }
    }

    public TSelf? PreviousNamedSibling
    {
        get
        {
            var node = Ts.node_prev_named_sibling(_node);
            return Ts.node_is_null(node) ? null : TSelf.Create(node);
        }
    }

    public TSelf? NextNamedSibling
    {
        get
        {
            var node = Ts.node_next_named_sibling(_node);
            return Ts.node_is_null(node) ? null : TSelf.Create(node);
        }
    }

    public TSelf? Parent
    {
        get
        {
            var node = Ts.node_parent(_node);
            return Ts.node_is_null(node) ? null : TSelf.Create(node);
        }
    }

    public bool IsNamed => Ts.node_is_named(_node);
    public bool IsMissing => Ts.node_is_missing(_node);
    public bool IsExtra => Ts.node_is_extra(_node);
    public bool IsNull => Ts.node_is_null(_node);

    public ImmutableArray<TSelf> Children => GetChildren().ToImmutableArray();
    public ImmutableArray<TSelf> NamedChildren => GetNamedChildren().ToImmutableArray();

    public TSelf GetChildByFieldName(string fieldName)
    {
        return TSelf.Create(Ts.node_child_by_field_name(_node, fieldName, (uint)fieldName.Length));
    }

    public TSelf GetChildByFieldId(ushort fieldId) => TSelf.Create(Ts.node_child_by_field_id(_node, fieldId));

    public string GetFieldNameForChild(uint childIndex) => Ts.node_field_name_for_child(_node, childIndex);

    public TSelf GetNamedChild(uint index)
    {
        return TSelf.Create(Ts.node_named_child(_node, index));
    }

    public TSelf GetChild(uint index)
    {
        return TSelf.Create(Ts.node_child(_node, index));
    }

    private IEnumerable<TSelf> GetNamedChildren()
    {
        for (uint i = 0; i < NamedChildCount; i++)
        {
            yield return GetNamedChild(i);
        }
    }

    private IEnumerable<TSelf> GetChildren()
    {
        for (uint i = 0; i < ChildCount; i++)
        {
            yield return GetChild(i);
        }
    }

    public TsNode ToUnmanaged()
    {
        return _node;
    }

    public string GetSExpression()
    {
        return Ts.node_string(_node);
    }

    protected bool Equals(TSelf other) => Ts.node_eq(_node, other._node);

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

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((TSelf)obj);
    }

    public override int GetHashCode() => _node.GetHashCode();
}
