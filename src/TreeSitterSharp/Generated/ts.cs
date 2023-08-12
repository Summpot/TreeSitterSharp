using System.Runtime.InteropServices;

namespace TreeSitterSharp.Native
{
#pragma warning disable CS8981
    public static unsafe partial class ts
#pragma warning restore CS8981
    {
        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_new", ExactSpelling = true)]
        public static extern TSParser* parser_new();

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_delete", ExactSpelling = true)]
        public static extern void parser_delete(TSParser* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_language", ExactSpelling = true)]
        [return: NativeTypeName("const TSLanguage *")]
        public static extern TSLanguage* parser_language([NativeTypeName("const TSParser *")] TSParser* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_set_language", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte parser_set_language(TSParser* self, [NativeTypeName("const TSLanguage *")] TSLanguage* language);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_set_included_ranges", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte parser_set_included_ranges(TSParser* self, [NativeTypeName("const TSRange *")] TSRange* ranges, [NativeTypeName("uint32_t")] uint count);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_included_ranges", ExactSpelling = true)]
        [return: NativeTypeName("const TSRange *")]
        public static extern TSRange* parser_included_ranges([NativeTypeName("const TSParser *")] TSParser* self, [NativeTypeName("uint32_t *")] uint* count);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_parse", ExactSpelling = true)]
        public static extern TSTree* parser_parse(TSParser* self, [NativeTypeName("const TSTree *")] TSTree* old_tree, TSInput input);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_parse_string", ExactSpelling = true)]
        public static extern TSTree* parser_parse_string(TSParser* self, [NativeTypeName("const TSTree *")] TSTree* old_tree, [NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("uint32_t")] uint length);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_parse_string_encoding", ExactSpelling = true)]
        public static extern TSTree* parser_parse_string_encoding(TSParser* self, [NativeTypeName("const TSTree *")] TSTree* old_tree, [NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("uint32_t")] uint length, TSInputEncoding encoding);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_reset", ExactSpelling = true)]
        public static extern void parser_reset(TSParser* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_set_timeout_micros", ExactSpelling = true)]
        public static extern void parser_set_timeout_micros(TSParser* self, [NativeTypeName("uint64_t")] ulong timeout_micros);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_timeout_micros", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong parser_timeout_micros([NativeTypeName("const TSParser *")] TSParser* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_set_cancellation_flag", ExactSpelling = true)]
        public static extern void parser_set_cancellation_flag(TSParser* self, [NativeTypeName("const size_t *")] nuint* flag);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_cancellation_flag", ExactSpelling = true)]
        [return: NativeTypeName("const size_t *")]
        public static extern nuint* parser_cancellation_flag([NativeTypeName("const TSParser *")] TSParser* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_set_logger", ExactSpelling = true)]
        public static extern void parser_set_logger(TSParser* self, TSLogger logger);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_logger", ExactSpelling = true)]
        public static extern TSLogger parser_logger([NativeTypeName("const TSParser *")] TSParser* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_parser_print_dot_graphs", ExactSpelling = true)]
        public static extern void parser_print_dot_graphs(TSParser* self, int fd);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_copy", ExactSpelling = true)]
        public static extern TSTree* tree_copy([NativeTypeName("const TSTree *")] TSTree* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_delete", ExactSpelling = true)]
        public static extern void tree_delete(TSTree* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_root_node", ExactSpelling = true)]
        public static extern TSNode tree_root_node([NativeTypeName("const TSTree *")] TSTree* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_root_node_with_offset", ExactSpelling = true)]
        public static extern TSNode tree_root_node_with_offset([NativeTypeName("const TSTree *")] TSTree* self, [NativeTypeName("uint32_t")] uint offset_bytes, TSPoint offset_extent);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_language", ExactSpelling = true)]
        [return: NativeTypeName("const TSLanguage *")]
        public static extern TSLanguage* tree_language([NativeTypeName("const TSTree *")] TSTree* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_included_ranges", ExactSpelling = true)]
        public static extern TSRange* tree_included_ranges([NativeTypeName("const TSTree *")] TSTree* self, [NativeTypeName("uint32_t *")] uint* length);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_edit", ExactSpelling = true)]
        public static extern void tree_edit(TSTree* self, [NativeTypeName("const TSInputEdit *")] TSInputEdit* edit);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_get_changed_ranges", ExactSpelling = true)]
        public static extern TSRange* tree_get_changed_ranges([NativeTypeName("const TSTree *")] TSTree* old_tree, [NativeTypeName("const TSTree *")] TSTree* new_tree, [NativeTypeName("uint32_t *")] uint* length);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_print_dot_graph", ExactSpelling = true)]
        public static extern void tree_print_dot_graph([NativeTypeName("const TSTree *")] TSTree* self, int file_descriptor);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_type", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* node_type(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_symbol", ExactSpelling = true)]
        [return: NativeTypeName("TSSymbol")]
        public static extern ushort node_symbol(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_language", ExactSpelling = true)]
        [return: NativeTypeName("const TSLanguage *")]
        public static extern TSLanguage* node_language(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_grammar_type", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* node_grammar_type(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_grammar_symbol", ExactSpelling = true)]
        [return: NativeTypeName("TSSymbol")]
        public static extern ushort node_grammar_symbol(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_start_byte", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint node_start_byte(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_start_point", ExactSpelling = true)]
        public static extern TSPoint node_start_point(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_end_byte", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint node_end_byte(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_end_point", ExactSpelling = true)]
        public static extern TSPoint node_end_point(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_string", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* node_string(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_is_null", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte node_is_null(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_is_named", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte node_is_named(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_is_missing", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte node_is_missing(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_is_extra", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte node_is_extra(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_has_changes", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte node_has_changes(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_has_error", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte node_has_error(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_is_error", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte node_is_error(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_parse_state", ExactSpelling = true)]
        [return: NativeTypeName("TSStateId")]
        public static extern ushort node_parse_state(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_next_parse_state", ExactSpelling = true)]
        [return: NativeTypeName("TSStateId")]
        public static extern ushort node_next_parse_state(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_parent", ExactSpelling = true)]
        public static extern TSNode node_parent(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_child", ExactSpelling = true)]
        public static extern TSNode node_child(TSNode self, [NativeTypeName("uint32_t")] uint child_index);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_field_name_for_child", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* node_field_name_for_child(TSNode self, [NativeTypeName("uint32_t")] uint child_index);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_child_count", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint node_child_count(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_named_child", ExactSpelling = true)]
        public static extern TSNode node_named_child(TSNode self, [NativeTypeName("uint32_t")] uint child_index);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_named_child_count", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint node_named_child_count(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_child_by_field_name", ExactSpelling = true)]
        public static extern TSNode node_child_by_field_name(TSNode self, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("uint32_t")] uint name_length);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_child_by_field_id", ExactSpelling = true)]
        public static extern TSNode node_child_by_field_id(TSNode self, [NativeTypeName("TSFieldId")] ushort field_id);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_next_sibling", ExactSpelling = true)]
        public static extern TSNode node_next_sibling(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_prev_sibling", ExactSpelling = true)]
        public static extern TSNode node_prev_sibling(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_next_named_sibling", ExactSpelling = true)]
        public static extern TSNode node_next_named_sibling(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_prev_named_sibling", ExactSpelling = true)]
        public static extern TSNode node_prev_named_sibling(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_first_child_for_byte", ExactSpelling = true)]
        public static extern TSNode node_first_child_for_byte(TSNode self, [NativeTypeName("uint32_t")] uint @byte);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_first_named_child_for_byte", ExactSpelling = true)]
        public static extern TSNode node_first_named_child_for_byte(TSNode self, [NativeTypeName("uint32_t")] uint @byte);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_descendant_count", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint node_descendant_count(TSNode self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_descendant_for_byte_range", ExactSpelling = true)]
        public static extern TSNode node_descendant_for_byte_range(TSNode self, [NativeTypeName("uint32_t")] uint start, [NativeTypeName("uint32_t")] uint end);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_descendant_for_point_range", ExactSpelling = true)]
        public static extern TSNode node_descendant_for_point_range(TSNode self, TSPoint start, TSPoint end);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_named_descendant_for_byte_range", ExactSpelling = true)]
        public static extern TSNode node_named_descendant_for_byte_range(TSNode self, [NativeTypeName("uint32_t")] uint start, [NativeTypeName("uint32_t")] uint end);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_named_descendant_for_point_range", ExactSpelling = true)]
        public static extern TSNode node_named_descendant_for_point_range(TSNode self, TSPoint start, TSPoint end);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_edit", ExactSpelling = true)]
        public static extern void node_edit(TSNode* self, [NativeTypeName("const TSInputEdit *")] TSInputEdit* edit);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_node_eq", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte node_eq(TSNode self, TSNode other);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_new", ExactSpelling = true)]
        public static extern TSTreeCursor tree_cursor_new(TSNode node);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_delete", ExactSpelling = true)]
        public static extern void tree_cursor_delete(TSTreeCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_reset", ExactSpelling = true)]
        public static extern void tree_cursor_reset(TSTreeCursor* self, TSNode node);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_reset_to", ExactSpelling = true)]
        public static extern void tree_cursor_reset_to(TSTreeCursor* dst, [NativeTypeName("const TSTreeCursor *")] TSTreeCursor* src);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_current_node", ExactSpelling = true)]
        public static extern TSNode tree_cursor_current_node([NativeTypeName("const TSTreeCursor *")] TSTreeCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_current_field_name", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* tree_cursor_current_field_name([NativeTypeName("const TSTreeCursor *")] TSTreeCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_current_field_id", ExactSpelling = true)]
        [return: NativeTypeName("TSFieldId")]
        public static extern ushort tree_cursor_current_field_id([NativeTypeName("const TSTreeCursor *")] TSTreeCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_goto_parent", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte tree_cursor_goto_parent(TSTreeCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_goto_next_sibling", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte tree_cursor_goto_next_sibling(TSTreeCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_goto_previous_sibling", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte tree_cursor_goto_previous_sibling(TSTreeCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_goto_first_child", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte tree_cursor_goto_first_child(TSTreeCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_goto_last_child", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte tree_cursor_goto_last_child(TSTreeCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_goto_descendant", ExactSpelling = true)]
        public static extern void tree_cursor_goto_descendant(TSTreeCursor* self, [NativeTypeName("uint32_t")] uint goal_descendant_index);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_current_descendant_index", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint tree_cursor_current_descendant_index([NativeTypeName("const TSTreeCursor *")] TSTreeCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_current_depth", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint tree_cursor_current_depth([NativeTypeName("const TSTreeCursor *")] TSTreeCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_goto_first_child_for_byte", ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long tree_cursor_goto_first_child_for_byte(TSTreeCursor* self, [NativeTypeName("uint32_t")] uint goal_byte);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_goto_first_child_for_point", ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long tree_cursor_goto_first_child_for_point(TSTreeCursor* self, TSPoint goal_point);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_tree_cursor_copy", ExactSpelling = true)]
        public static extern TSTreeCursor tree_cursor_copy([NativeTypeName("const TSTreeCursor *")] TSTreeCursor* cursor);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_new", ExactSpelling = true)]
        public static extern TSQuery* query_new([NativeTypeName("const TSLanguage *")] TSLanguage* language, [NativeTypeName("const char *")] sbyte* source, [NativeTypeName("uint32_t")] uint source_len, [NativeTypeName("uint32_t *")] uint* error_offset, TSQueryError* error_type);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_delete", ExactSpelling = true)]
        public static extern void query_delete(TSQuery* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_pattern_count", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint query_pattern_count([NativeTypeName("const TSQuery *")] TSQuery* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_capture_count", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint query_capture_count([NativeTypeName("const TSQuery *")] TSQuery* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_string_count", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint query_string_count([NativeTypeName("const TSQuery *")] TSQuery* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_start_byte_for_pattern", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint query_start_byte_for_pattern([NativeTypeName("const TSQuery *")] TSQuery* self, [NativeTypeName("uint32_t")] uint pattern_index);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_predicates_for_pattern", ExactSpelling = true)]
        [return: NativeTypeName("const TSQueryPredicateStep *")]
        public static extern TSQueryPredicateStep* query_predicates_for_pattern([NativeTypeName("const TSQuery *")] TSQuery* self, [NativeTypeName("uint32_t")] uint pattern_index, [NativeTypeName("uint32_t *")] uint* step_count);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_is_pattern_rooted", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte query_is_pattern_rooted([NativeTypeName("const TSQuery *")] TSQuery* self, [NativeTypeName("uint32_t")] uint pattern_index);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_is_pattern_non_local", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte query_is_pattern_non_local([NativeTypeName("const TSQuery *")] TSQuery* self, [NativeTypeName("uint32_t")] uint pattern_index);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_is_pattern_guaranteed_at_step", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte query_is_pattern_guaranteed_at_step([NativeTypeName("const TSQuery *")] TSQuery* self, [NativeTypeName("uint32_t")] uint byte_offset);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_capture_name_for_id", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* query_capture_name_for_id([NativeTypeName("const TSQuery *")] TSQuery* self, [NativeTypeName("uint32_t")] uint index, [NativeTypeName("uint32_t *")] uint* length);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_capture_quantifier_for_id", ExactSpelling = true)]
        public static extern TSQuantifier query_capture_quantifier_for_id([NativeTypeName("const TSQuery *")] TSQuery* self, [NativeTypeName("uint32_t")] uint pattern_index, [NativeTypeName("uint32_t")] uint capture_index);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_string_value_for_id", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* query_string_value_for_id([NativeTypeName("const TSQuery *")] TSQuery* self, [NativeTypeName("uint32_t")] uint index, [NativeTypeName("uint32_t *")] uint* length);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_disable_capture", ExactSpelling = true)]
        public static extern void query_disable_capture(TSQuery* self, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("uint32_t")] uint length);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_disable_pattern", ExactSpelling = true)]
        public static extern void query_disable_pattern(TSQuery* self, [NativeTypeName("uint32_t")] uint pattern_index);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_new", ExactSpelling = true)]
        public static extern TSQueryCursor* query_cursor_new();

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_delete", ExactSpelling = true)]
        public static extern void query_cursor_delete(TSQueryCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_exec", ExactSpelling = true)]
        public static extern void query_cursor_exec(TSQueryCursor* self, [NativeTypeName("const TSQuery *")] TSQuery* query, TSNode node);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_did_exceed_match_limit", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte query_cursor_did_exceed_match_limit([NativeTypeName("const TSQueryCursor *")] TSQueryCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_match_limit", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint query_cursor_match_limit([NativeTypeName("const TSQueryCursor *")] TSQueryCursor* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_set_match_limit", ExactSpelling = true)]
        public static extern void query_cursor_set_match_limit(TSQueryCursor* self, [NativeTypeName("uint32_t")] uint limit);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_set_byte_range", ExactSpelling = true)]
        public static extern void query_cursor_set_byte_range(TSQueryCursor* self, [NativeTypeName("uint32_t")] uint start_byte, [NativeTypeName("uint32_t")] uint end_byte);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_set_point_range", ExactSpelling = true)]
        public static extern void query_cursor_set_point_range(TSQueryCursor* self, TSPoint start_point, TSPoint end_point);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_next_match", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte query_cursor_next_match(TSQueryCursor* self, TSQueryMatch* match);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_remove_match", ExactSpelling = true)]
        public static extern void query_cursor_remove_match(TSQueryCursor* self, [NativeTypeName("uint32_t")] uint match_id);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_next_capture", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte query_cursor_next_capture(TSQueryCursor* self, TSQueryMatch* match, [NativeTypeName("uint32_t *")] uint* capture_index);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_query_cursor_set_max_start_depth", ExactSpelling = true)]
        public static extern void query_cursor_set_max_start_depth(TSQueryCursor* self, [NativeTypeName("uint32_t")] uint max_start_depth);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_symbol_count", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint language_symbol_count([NativeTypeName("const TSLanguage *")] TSLanguage* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_state_count", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint language_state_count([NativeTypeName("const TSLanguage *")] TSLanguage* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_symbol_name", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* language_symbol_name([NativeTypeName("const TSLanguage *")] TSLanguage* self, [NativeTypeName("TSSymbol")] ushort symbol);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_symbol_for_name", ExactSpelling = true)]
        [return: NativeTypeName("TSSymbol")]
        public static extern ushort language_symbol_for_name([NativeTypeName("const TSLanguage *")] TSLanguage* self, [NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("uint32_t")] uint length, [NativeTypeName("bool")] byte is_named);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_field_count", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint language_field_count([NativeTypeName("const TSLanguage *")] TSLanguage* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_field_name_for_id", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* language_field_name_for_id([NativeTypeName("const TSLanguage *")] TSLanguage* self, [NativeTypeName("TSFieldId")] ushort id);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_field_id_for_name", ExactSpelling = true)]
        [return: NativeTypeName("TSFieldId")]
        public static extern ushort language_field_id_for_name([NativeTypeName("const TSLanguage *")] TSLanguage* self, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("uint32_t")] uint name_length);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_symbol_type", ExactSpelling = true)]
        public static extern TSSymbolType language_symbol_type([NativeTypeName("const TSLanguage *")] TSLanguage* self, [NativeTypeName("TSSymbol")] ushort symbol);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_version", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint language_version([NativeTypeName("const TSLanguage *")] TSLanguage* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_language_next_state", ExactSpelling = true)]
        [return: NativeTypeName("TSStateId")]
        public static extern ushort language_next_state([NativeTypeName("const TSLanguage *")] TSLanguage* self, [NativeTypeName("TSStateId")] ushort state, [NativeTypeName("TSSymbol")] ushort symbol);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_lookahead_iterator_new", ExactSpelling = true)]
        public static extern TSLookaheadIterator* lookahead_iterator_new([NativeTypeName("const TSLanguage *")] TSLanguage* self, [NativeTypeName("TSStateId")] ushort state);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_lookahead_iterator_delete", ExactSpelling = true)]
        public static extern void lookahead_iterator_delete(TSLookaheadIterator* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_lookahead_iterator_reset_state", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte lookahead_iterator_reset_state(TSLookaheadIterator* self, [NativeTypeName("TSStateId")] ushort state);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_lookahead_iterator_reset", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte lookahead_iterator_reset(TSLookaheadIterator* self, [NativeTypeName("const TSLanguage *")] TSLanguage* language, [NativeTypeName("TSStateId")] ushort state);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_lookahead_iterator_language", ExactSpelling = true)]
        [return: NativeTypeName("const TSLanguage *")]
        public static extern TSLanguage* lookahead_iterator_language([NativeTypeName("const TSLookaheadIterator *")] TSLookaheadIterator* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_lookahead_iterator_next", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte lookahead_iterator_next(TSLookaheadIterator* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_lookahead_iterator_current_symbol", ExactSpelling = true)]
        [return: NativeTypeName("TSSymbol")]
        public static extern ushort lookahead_iterator_current_symbol([NativeTypeName("const TSLookaheadIterator *")] TSLookaheadIterator* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_lookahead_iterator_current_symbol_name", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lookahead_iterator_current_symbol_name([NativeTypeName("const TSLookaheadIterator *")] TSLookaheadIterator* self);

        [DllImport("libtree-sitter", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ts_set_allocator", ExactSpelling = true)]
        public static extern void set_allocator([NativeTypeName("void *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, void*> new_malloc, [NativeTypeName("void *(*)(size_t, size_t)")] delegate* unmanaged[Cdecl]<nuint, nuint, void*> new_calloc, [NativeTypeName("void *(*)(void *, size_t)")] delegate* unmanaged[Cdecl]<void*, nuint, void*> new_realloc, [NativeTypeName("void (*)(void *)")] delegate* unmanaged[Cdecl]<void*, void> new_free);
    }
}
