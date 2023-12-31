using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TreeSitterSharp.Native;

public static unsafe partial class Ts
{
    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_new",
        ExactSpelling = true)]
    public static extern TsParser* parser_new();

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_delete",
        ExactSpelling = true)]
    public static extern void parser_delete(TsParser* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_language",
        ExactSpelling = true)]
    [return: NativeTypeName("const TsLanguage *")]
    public static extern TsLanguage* parser_language([NativeTypeName("const Parser *")] TsParser* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_set_language",
        ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte parser_set_language(TsParser* self, TsLanguage* language);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_parser_set_included_ranges", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte parser_set_included_ranges(TsParser* self,
        [NativeTypeName("const TsRange *")] TsRange* ranges, [NativeTypeName("uint32_t")] uint count);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_included_ranges",
        ExactSpelling = true)]
    [return: NativeTypeName("const TsRange *")]
    public static extern TsRange* parser_included_ranges([NativeTypeName("const Parser *")] TsParser* self,
        [NativeTypeName("uint32_t *")] uint* count);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_parse",
        ExactSpelling = true)]
    public static extern TsTree* parser_parse(TsParser* self, [NativeTypeName("const Tree *")] TsTree* old_tree,
        TsInput input);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_parse_string",
        ExactSpelling = true)]
    public static extern TsTree* parser_parse_string(TsParser* self, TsTree* old_tree, string code, uint length);

    [LibraryImport("tree-sitter", EntryPoint = "ts_parser_parse_string_encoding")]
    internal static partial TsTree* parser_parse_string_encoding(TsParser* self, TsTree* oldTree, byte[] code, uint length, TsInputEncoding encoding);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_reset",
        ExactSpelling = true)]
    public static extern void parser_reset(TsParser* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_parser_set_timeout_micros", ExactSpelling = true)]
    public static extern void parser_set_timeout_micros(TsParser* self,
        [NativeTypeName("uint64_t")] ulong timeout_micros);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_timeout_micros",
        ExactSpelling = true)]
    [return: NativeTypeName("uint64_t")]
    public static extern ulong parser_timeout_micros([NativeTypeName("const Parser *")] TsParser* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_parser_set_cancellation_flag", ExactSpelling = true)]
    public static extern void parser_set_cancellation_flag(TsParser* self,
        [NativeTypeName("const size_t *")] nuint* flag);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_parser_cancellation_flag", ExactSpelling = true)]
    [return: NativeTypeName("const size_t *")]
    public static extern nuint* parser_cancellation_flag([NativeTypeName("const Parser *")] TsParser* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_set_logger",
        ExactSpelling = true)]
    public static extern void parser_set_logger(TsParser* self, TsLogger logger);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_logger",
        ExactSpelling = true)]
    public static extern TsLogger parser_logger([NativeTypeName("const Parser *")] TsParser* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_print_dot_graphs",
        ExactSpelling = true)]
    public static extern void parser_print_dot_graphs(TsParser* self, int fd);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_copy",
        ExactSpelling = true)]
    public static extern TsTree* tree_copy([NativeTypeName("const Tree *")] TsTree* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_delete",
        ExactSpelling = true)]
    public static extern void tree_delete(TsTree* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_root_node",
        ExactSpelling = true)]
    public static extern TsNode tree_root_node(TsTree* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_root_node_with_offset", ExactSpelling = true)]
    public static extern TsNode tree_root_node_with_offset([NativeTypeName("const Tree *")] TsTree* self,
        [NativeTypeName("uint32_t")] uint offset_bytes, Point offset_extent);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_language",
        ExactSpelling = true)]
    [return: NativeTypeName("const TsLanguage *")]
    public static extern TsLanguage* tree_language([NativeTypeName("const Tree *")] TsTree* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_included_ranges",
        ExactSpelling = true)]
    public static extern TsRange* tree_included_ranges([NativeTypeName("const Tree *")] TsTree* self,
        [NativeTypeName("uint32_t *")] uint* length);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_edit",
        ExactSpelling = true)]
    public static extern void tree_edit(TsTree* self, [NativeTypeName("const TsInputEdit *")] TsInputEdit* edit);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_get_changed_ranges",
        ExactSpelling = true)]
    public static extern TsRange* tree_get_changed_ranges([NativeTypeName("const Tree *")] TsTree* old_tree,
        [NativeTypeName("const Tree *")] TsTree* new_tree, [NativeTypeName("uint32_t *")] uint* length);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_print_dot_graph",
        ExactSpelling = true)]
    public static extern void
        tree_print_dot_graph([NativeTypeName("const Tree *")] TsTree* self, int file_descriptor);

    [LibraryImport("tree-sitter", EntryPoint = "ts_node_type", StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(ConstantStringMarshaller))]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string node_type(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_symbol",
        ExactSpelling = true)]
    [return: NativeTypeName("TSSymbol")]
    public static extern ushort node_symbol(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_language",
        ExactSpelling = true)]
    [return: NativeTypeName("const TsLanguage *")]
    public static extern TsLanguage* node_language(TsNode self);

    [LibraryImport("tree-sitter", EntryPoint = "ts_node_grammar_type", StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(ConstantStringMarshaller))]
    public static partial string node_grammar_type(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_grammar_symbol",
        ExactSpelling = true)]
    [return: NativeTypeName("TSSymbol")]
    public static extern ushort node_grammar_symbol(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_start_byte",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint node_start_byte(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_start_point",
        ExactSpelling = true)]
    public static extern Point node_start_point(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_end_byte",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint node_end_byte(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_end_point",
        ExactSpelling = true)]
    public static extern Point node_end_point(TsNode self);

    [LibraryImport("tree-sitter", EntryPoint = "ts_node_string", StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringMarshaller))]
    public static partial string node_string(TsNode self);

    [DllImport("tree-sitter", EntryPoint = "ts_node_is_null")]
    public static extern bool node_is_null(TsNode self);

    [DllImport("tree-sitter", EntryPoint = "ts_node_is_named")]
    public static extern bool node_is_named(TsNode self);

    [DllImport("tree-sitter", EntryPoint = "ts_node_is_missing")]
    public static extern bool node_is_missing(TsNode self);

    [DllImport("tree-sitter", EntryPoint = "ts_node_is_extra")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool node_is_extra(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_has_changes",
        ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte node_has_changes(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_has_error",
        ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte node_has_error(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_is_error",
        ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte node_is_error(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_parse_state",
        ExactSpelling = true)]
    [return: NativeTypeName("TSStateId")]
    public static extern ushort node_parse_state(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_next_parse_state",
        ExactSpelling = true)]
    [return: NativeTypeName("TSStateId")]
    public static extern ushort node_next_parse_state(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_parent",
        ExactSpelling = true)]
    public static extern TsNode node_parent(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_child",
        ExactSpelling = true)]
    public static extern TsNode node_child(TsNode self, [NativeTypeName("uint32_t")] uint child_index);

    [LibraryImport("tree-sitter", EntryPoint = "ts_node_field_name_for_child", StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringMarshaller))]
    public static partial string node_field_name_for_child(TsNode self, [NativeTypeName("uint32_t")] uint child_index);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_child_count",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint node_child_count(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_named_child",
        ExactSpelling = true)]
    public static extern TsNode node_named_child(TsNode self, [NativeTypeName("uint32_t")] uint child_index);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_named_child_count",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint node_named_child_count(TsNode self);

    [LibraryImport("tree-sitter", EntryPoint = "ts_node_child_by_field_name")]
    public static partial TsNode node_child_by_field_name(TsNode self, [MarshalAs(UnmanagedType.LPStr)] string name, uint name_length);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_child_by_field_id",
        ExactSpelling = true)]
    public static extern TsNode node_child_by_field_id(TsNode self, [NativeTypeName("TSFieldId")] ushort field_id);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_next_sibling",
        ExactSpelling = true)]
    public static extern TsNode node_next_sibling(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_prev_sibling",
        ExactSpelling = true)]
    public static extern TsNode node_prev_sibling(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_next_named_sibling",
        ExactSpelling = true)]
    public static extern TsNode node_next_named_sibling(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_prev_named_sibling",
        ExactSpelling = true)]
    public static extern TsNode node_prev_named_sibling(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_node_first_child_for_byte", ExactSpelling = true)]
    public static extern TsNode node_first_child_for_byte(TsNode self, [NativeTypeName("uint32_t")] uint @byte);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_node_first_named_child_for_byte", ExactSpelling = true)]
    public static extern TsNode node_first_named_child_for_byte(TsNode self, [NativeTypeName("uint32_t")] uint @byte);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_descendant_count",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint node_descendant_count(TsNode self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_node_descendant_for_byte_range", ExactSpelling = true)]
    public static extern TsNode node_descendant_for_byte_range(TsNode self, [NativeTypeName("uint32_t")] uint start,
        [NativeTypeName("uint32_t")] uint end);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_node_descendant_for_point_range", ExactSpelling = true)]
    public static extern TsNode node_descendant_for_point_range(TsNode self, Point start, Point end);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_node_named_descendant_for_byte_range", ExactSpelling = true)]
    public static extern TsNode node_named_descendant_for_byte_range(TsNode self,
        [NativeTypeName("uint32_t")] uint start, [NativeTypeName("uint32_t")] uint end);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_node_named_descendant_for_point_range", ExactSpelling = true)]
    public static extern TsNode node_named_descendant_for_point_range(TsNode self, Point start, Point end);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_edit",
        ExactSpelling = true)]
    public static extern void node_edit(TsNode* self, [NativeTypeName("const TsInputEdit *")] TsInputEdit* edit);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_eq",
        ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern bool node_eq(TsNode self, TsNode other);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_new",
        ExactSpelling = true)]
    public static extern TsTreeCursor tree_cursor_new(TsNode node);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_delete",
        ExactSpelling = true)]
    public static extern void tree_cursor_delete(in TsTreeCursor self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_reset",
        ExactSpelling = true)]
    public static extern void tree_cursor_reset(in TsTreeCursor self, TsNode node);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_reset_to",
        ExactSpelling = true)]
    public static extern void tree_cursor_reset_to(in TsTreeCursor dst,
        in TsTreeCursor src);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_current_node", ExactSpelling = true)]
    public static extern TsNode tree_cursor_current_node(in TsTreeCursor self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_current_field_name", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern string tree_cursor_current_field_name(
        in TsTreeCursor self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_current_field_id", ExactSpelling = true)]
    [return: NativeTypeName("TSFieldId")]
    public static extern ushort tree_cursor_current_field_id(in TsTreeCursor self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_goto_parent",
        ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern bool tree_cursor_goto_parent(in TsTreeCursor self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_goto_next_sibling", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern bool tree_cursor_goto_next_sibling(in TsTreeCursor self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_goto_previous_sibling", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern bool tree_cursor_goto_previous_sibling(in TsTreeCursor self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_goto_first_child", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern bool tree_cursor_goto_first_child(in TsTreeCursor self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_goto_last_child", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern bool tree_cursor_goto_last_child(in TsTreeCursor self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_goto_descendant", ExactSpelling = true)]
    public static extern void tree_cursor_goto_descendant(in TsTreeCursor self, uint goal_descendant_index);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_current_descendant_index", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint tree_cursor_current_descendant_index(
        in TsTreeCursor self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_current_depth", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint tree_cursor_current_depth(in TsTreeCursor self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_goto_first_child_for_byte", ExactSpelling = true)]
    [return: NativeTypeName("int64_t")]
    public static extern long tree_cursor_goto_first_child_for_byte(in TsTreeCursor self, uint goal_byte);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_tree_cursor_goto_first_child_for_point", ExactSpelling = true)]
    [return: NativeTypeName("int64_t")]
    public static extern long tree_cursor_goto_first_child_for_point(in TsTreeCursor self, Point goal_point);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_copy",
        ExactSpelling = true)]
    public static extern TsTreeCursor tree_cursor_copy(in TsTreeCursor cursor);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_new",
        ExactSpelling = true)]
    public static extern TsQuery* query_new([NativeTypeName("const TsLanguage *")] TsLanguage* language,
        [NativeTypeName("const char *")] string source, [NativeTypeName("uint32_t")] uint source_len,
        [NativeTypeName("uint32_t *")] uint* error_offset, TsQueryError* error_type);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_delete",
        ExactSpelling = true)]
    public static extern void query_delete(TsQuery* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_pattern_count",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint query_pattern_count([NativeTypeName("const Query *")] TsQuery* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_capture_count",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint query_capture_count([NativeTypeName("const Query *")] TsQuery* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_string_count",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint query_string_count([NativeTypeName("const Query *")] TsQuery* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_start_byte_for_pattern", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint query_start_byte_for_pattern([NativeTypeName("const Query *")] TsQuery* self,
        [NativeTypeName("uint32_t")] uint pattern_index);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_predicates_for_pattern", ExactSpelling = true)]
    [return: NativeTypeName("const TsQueryPredicateStep *")]
    public static extern TsQueryPredicateStep* query_predicates_for_pattern(
        [NativeTypeName("const Query *")] TsQuery* self, [NativeTypeName("uint32_t")] uint pattern_index,
        [NativeTypeName("uint32_t *")] uint* step_count);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_is_pattern_rooted",
        ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte query_is_pattern_rooted([NativeTypeName("const Query *")] TsQuery* self,
        [NativeTypeName("uint32_t")] uint pattern_index);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_is_pattern_non_local", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte query_is_pattern_non_local([NativeTypeName("const Query *")] TsQuery* self,
        [NativeTypeName("uint32_t")] uint pattern_index);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_is_pattern_guaranteed_at_step", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte query_is_pattern_guaranteed_at_step([NativeTypeName("const Query *")] TsQuery* self,
        [NativeTypeName("uint32_t")] uint byte_offset);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_capture_name_for_id", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern string query_capture_name_for_id([NativeTypeName("const Query *")] TsQuery* self,
        [NativeTypeName("uint32_t")] uint index, [NativeTypeName("uint32_t *")] uint* length);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_capture_quantifier_for_id", ExactSpelling = true)]
    public static extern TsQuantifier query_capture_quantifier_for_id([NativeTypeName("const Query *")] TsQuery* self,
        [NativeTypeName("uint32_t")] uint pattern_index, [NativeTypeName("uint32_t")] uint capture_index);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_string_value_for_id", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern string query_string_value_for_id([NativeTypeName("const Query *")] TsQuery* self,
        [NativeTypeName("uint32_t")] uint index, [NativeTypeName("uint32_t *")] uint* length);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_disable_capture",
        ExactSpelling = true)]
    public static extern void query_disable_capture(TsQuery* self, [NativeTypeName("const char *")] string name,
        [NativeTypeName("uint32_t")] uint length);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_disable_pattern",
        ExactSpelling = true)]
    public static extern void query_disable_pattern(TsQuery* self, [NativeTypeName("uint32_t")] uint pattern_index);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_new",
        ExactSpelling = true)]
    public static extern TsQueryCursor* query_cursor_new();

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_delete",
        ExactSpelling = true)]
    public static extern void query_cursor_delete(TsQueryCursor* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_exec",
        ExactSpelling = true)]
    public static extern void query_cursor_exec(TsQueryCursor* self, [NativeTypeName("const Query *")] TsQuery* query,
        TsNode node);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_cursor_did_exceed_match_limit", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte query_cursor_did_exceed_match_limit(
        [NativeTypeName("const TsQueryCursor *")] TsQueryCursor* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_cursor_match_limit", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint query_cursor_match_limit([NativeTypeName("const TsQueryCursor *")] TsQueryCursor* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_cursor_set_match_limit", ExactSpelling = true)]
    public static extern void
        query_cursor_set_match_limit(TsQueryCursor* self, [NativeTypeName("uint32_t")] uint limit);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_cursor_set_byte_range", ExactSpelling = true)]
    public static extern void query_cursor_set_byte_range(TsQueryCursor* self,
        [NativeTypeName("uint32_t")] uint start_byte, [NativeTypeName("uint32_t")] uint end_byte);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_cursor_set_point_range", ExactSpelling = true)]
    public static extern void query_cursor_set_point_range(TsQueryCursor* self, Point start_point, Point end_point);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_next_match",
        ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern bool query_cursor_next_match(TsQueryCursor* self, TsQueryMatch* match);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_cursor_remove_match", ExactSpelling = true)]
    public static extern void
        query_cursor_remove_match(TsQueryCursor* self, [NativeTypeName("uint32_t")] uint match_id);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_cursor_next_capture", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern bool query_cursor_next_capture(TsQueryCursor* self, TsQueryMatch* match,
        [NativeTypeName("uint32_t *")] uint* capture_index);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_query_cursor_set_max_start_depth", ExactSpelling = true)]
    public static extern void query_cursor_set_max_start_depth(TsQueryCursor* self,
        [NativeTypeName("uint32_t")] uint max_start_depth);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_symbol_count",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint language_symbol_count([NativeTypeName("const TsLanguage *")] TsLanguage* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_state_count",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint language_state_count([NativeTypeName("const TsLanguage *")] TsLanguage* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_symbol_name",
        ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern string language_symbol_name([NativeTypeName("const TsLanguage *")] TsLanguage* self,
        [NativeTypeName("TSSymbol")] ushort symbol);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_language_symbol_for_name", ExactSpelling = true)]
    [return: NativeTypeName("TSSymbol")]
    public static extern ushort language_symbol_for_name([NativeTypeName("const TsLanguage *")] TsLanguage* self,
        [NativeTypeName("const char *")] string @string, [NativeTypeName("uint32_t")] uint length,
        [NativeTypeName("bool")] byte is_named);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_field_count",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint language_field_count([NativeTypeName("const TsLanguage *")] TsLanguage* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_language_field_name_for_id", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern string language_field_name_for_id([NativeTypeName("const TsLanguage *")] TsLanguage* self,
        [NativeTypeName("TSFieldId")] ushort id);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_language_field_id_for_name", ExactSpelling = true)]
    [return: NativeTypeName("TSFieldId")]
    public static extern ushort language_field_id_for_name([NativeTypeName("const TsLanguage *")] TsLanguage* self,
        [NativeTypeName("const char *")] string name, [NativeTypeName("uint32_t")] uint name_length);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_symbol_type",
        ExactSpelling = true)]
    public static extern TsSymbolType language_symbol_type([NativeTypeName("const TsLanguage *")] TsLanguage* self,
        [NativeTypeName("TSSymbol")] ushort symbol);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_version",
        ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint language_version([NativeTypeName("const TsLanguage *")] TsLanguage* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_next_state",
        ExactSpelling = true)]
    [return: NativeTypeName("TSStateId")]
    public static extern ushort language_next_state([NativeTypeName("const TsLanguage *")] TsLanguage* self,
        [NativeTypeName("TSStateId")] ushort state, [NativeTypeName("TSSymbol")] ushort symbol);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_lookahead_iterator_new",
        ExactSpelling = true)]
    public static extern TsLookaheadIterator* lookahead_iterator_new(
        [NativeTypeName("const TsLanguage *")] TsLanguage* self, [NativeTypeName("TSStateId")] ushort state);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_lookahead_iterator_delete", ExactSpelling = true)]
    public static extern void lookahead_iterator_delete(TsLookaheadIterator* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_lookahead_iterator_reset_state", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte lookahead_iterator_reset_state(TsLookaheadIterator* self,
        [NativeTypeName("TSStateId")] ushort state);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_lookahead_iterator_reset", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte lookahead_iterator_reset(TsLookaheadIterator* self,
        [NativeTypeName("const TsLanguage *")] TsLanguage* language, [NativeTypeName("TSStateId")] ushort state);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_lookahead_iterator_language", ExactSpelling = true)]
    [return: NativeTypeName("const TsLanguage *")]
    public static extern TsLanguage* lookahead_iterator_language(
        [NativeTypeName("const TsLookaheadIterator *")] TsLookaheadIterator* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_lookahead_iterator_next",
        ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte lookahead_iterator_next(TsLookaheadIterator* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_lookahead_iterator_current_symbol", ExactSpelling = true)]
    [return: NativeTypeName("TSSymbol")]
    public static extern ushort lookahead_iterator_current_symbol(
        [NativeTypeName("const TsLookaheadIterator *")] TsLookaheadIterator* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ts_lookahead_iterator_current_symbol_name", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern string lookahead_iterator_current_symbol_name(
        [NativeTypeName("const TsLookaheadIterator *")] TsLookaheadIterator* self);

    [DllImport("tree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_set_allocator",
        ExactSpelling = true)]
    public static extern void set_allocator(
        delegate* managed<nuint, void*> new_malloc,
        delegate* managed<nuint, nuint, void*> new_calloc,
        delegate* managed<void*, nuint, void*> new_realloc,
        delegate* managed<void*, void> new_free);
}
