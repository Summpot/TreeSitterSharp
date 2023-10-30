using TreeSitterSharp.Native;

namespace TreeSitterSharp;
public class TsTreeCursor
{
    private readonly Native.TsTreeCursor _treeCursor;
    private readonly Native.TsNode _node;

    public TsTreeCursor(TsNode node)
    {
        _node = node.ToUnmanaged();
        _treeCursor = Ts.tree_cursor_new(_node);
    }

    private TsTreeCursor(Native.TsTreeCursor treeCursor) => _treeCursor = treeCursor;

    ~TsTreeCursor()
    {
        Ts.tree_cursor_delete(_treeCursor);
    }

    public uint CurrentDepth => Ts.tree_cursor_current_depth(in _treeCursor);
    public TsNode CurrentNode => new(Ts.tree_cursor_current_node(in _treeCursor));
    public string CurrentFieldName => Ts.tree_cursor_current_field_name(in _treeCursor);
    public ushort CurrentFieldId => Ts.tree_cursor_current_field_id(in _treeCursor);
    public uint CurrentDescendantIndex => Ts.tree_cursor_current_descendant_index(in _treeCursor);

    public bool GotoParent() => Ts.tree_cursor_goto_parent(in _treeCursor);
    public bool GotoFirstChild() => Ts.tree_cursor_goto_first_child(in _treeCursor);
    public long GotoFirstChildForByte(uint goalByte) => Ts.tree_cursor_goto_first_child_for_byte(in _treeCursor, goalByte);
    public long GotoFirstChildForPoint(TsPoint point) => Ts.tree_cursor_goto_first_child_for_point(in _treeCursor, point);
    public bool GotoLastChild() => Ts.tree_cursor_goto_last_child(in _treeCursor);
    public bool GotoNextSibling() => Ts.tree_cursor_goto_next_sibling(in _treeCursor);
    public bool GotoPreviousSibling() => Ts.tree_cursor_goto_previous_sibling(in _treeCursor);
    public void GotoDescendant(uint descendantIndex) => Ts.tree_cursor_goto_descendant(in _treeCursor, descendantIndex);

    public void Reset()
    {
        Ts.tree_cursor_reset(_treeCursor, _node);
    }

    public void ResetTo(TsTreeCursor dst)
    {
        Ts.tree_cursor_reset_to(dst._treeCursor, _treeCursor);
    }

    public TsTreeCursor Copy()
    {
        return new TsTreeCursor(Ts.tree_cursor_copy(_treeCursor));
    }
}
