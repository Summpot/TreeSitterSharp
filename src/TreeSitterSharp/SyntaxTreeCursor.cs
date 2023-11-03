using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public class SyntaxTreeCursor
{
    private readonly TsTreeCursor _treeCursor;
    private readonly TsNode _node;

    public SyntaxTreeCursor(TreeSitterSyntaxNode node)
    {
        _node = node.ToUnmanaged();
        _treeCursor = Ts.tree_cursor_new(_node);
    }

    private SyntaxTreeCursor(TsTreeCursor treeCursor) => _treeCursor = treeCursor;

    ~SyntaxTreeCursor()
    {
        Ts.tree_cursor_delete(_treeCursor);
    }

    public uint CurrentDepth => Ts.tree_cursor_current_depth(in _treeCursor);
    public TreeSitterSyntaxNode CurrentNode => new(Ts.tree_cursor_current_node(in _treeCursor));
    public string CurrentFieldName => Ts.tree_cursor_current_field_name(in _treeCursor);
    public ushort CurrentFieldId => Ts.tree_cursor_current_field_id(in _treeCursor);
    public uint CurrentDescendantIndex => Ts.tree_cursor_current_descendant_index(in _treeCursor);

    public bool GotoParent() => Ts.tree_cursor_goto_parent(in _treeCursor);
    public bool GotoFirstChild() => Ts.tree_cursor_goto_first_child(in _treeCursor);
    public long GotoFirstChildForByte(uint goalByte) => Ts.tree_cursor_goto_first_child_for_byte(in _treeCursor, goalByte);
    public long GotoFirstChildForPoint(Point point) => Ts.tree_cursor_goto_first_child_for_point(in _treeCursor, point);
    public bool GotoLastChild() => Ts.tree_cursor_goto_last_child(in _treeCursor);
    public bool GotoNextSibling() => Ts.tree_cursor_goto_next_sibling(in _treeCursor);
    public bool GotoPreviousSibling() => Ts.tree_cursor_goto_previous_sibling(in _treeCursor);
    public void GotoDescendant(uint descendantIndex) => Ts.tree_cursor_goto_descendant(in _treeCursor, descendantIndex);

    public void Reset()
    {
        Ts.tree_cursor_reset(_treeCursor, _node);
    }

    public void ResetTo(SyntaxTreeCursor dst)
    {
        Ts.tree_cursor_reset_to(dst._treeCursor, _treeCursor);
    }

    public SyntaxTreeCursor Copy()
    {
        return new SyntaxTreeCursor(Ts.tree_cursor_copy(_treeCursor));
    }
}
