namespace TreeSitterSharp.Native;

public unsafe partial struct TsLanguage
{
    [NativeTypeName("uint32_t")]
    public uint version;

    [NativeTypeName("uint32_t")]
    public uint symbol_count;

    [NativeTypeName("uint32_t")]
    public uint alias_count;

    [NativeTypeName("uint32_t")]
    public uint token_count;

    [NativeTypeName("uint32_t")]
    public uint external_token_count;

    [NativeTypeName("uint32_t")]
    public uint state_count;

    [NativeTypeName("uint32_t")]
    public uint large_state_count;

    [NativeTypeName("uint32_t")]
    public uint production_id_count;

    [NativeTypeName("uint32_t")]
    public uint field_count;

    [NativeTypeName("uint16_t")]
    public ushort max_alias_sequence_length;

    [NativeTypeName("const uint16_t *")]
    public ushort* parse_table;

    [NativeTypeName("const uint16_t *")]
    public ushort* small_parse_table;

    [NativeTypeName("const uint32_t *")]
    public uint* small_parse_table_map;

    [NativeTypeName("const TsParseActionEntry *")]
    public TsParseActionEntry* parse_actions;

    [NativeTypeName("const char *const *")]
    public string[] symbol_names;

    [NativeTypeName("const char *const *")]
    public string[] field_names;

    [NativeTypeName("const TsFieldMapSlice *")]
    public TsFieldMapSlice* field_map_slices;

    [NativeTypeName("const TsFieldMapEntry *")]
    public TsFieldMapEntry* field_map_entries;

    [NativeTypeName("const TSSymbolMetadata *")]
    public TsSymbolMetadata* symbol_metadata;

    [NativeTypeName("const TSSymbol *")]
    public ushort* public_symbol_map;

    [NativeTypeName("const uint16_t *")]
    public ushort* alias_map;

    [NativeTypeName("const TSSymbol *")]
    public ushort* alias_sequences;

    [NativeTypeName("const TsLexMode *")]
    public TsLexMode* lex_modes;

    [NativeTypeName("bool (*)(TsLexer *, TSStateId)")]
    public delegate* unmanaged[Cdecl]<TsLexer*, ushort, byte> lex_fn;

    [NativeTypeName("bool (*)(TsLexer *, TSStateId)")]
    public delegate* unmanaged[Cdecl]<TsLexer*, ushort, byte> keyword_lex_fn;

    [NativeTypeName("TSSymbol")]
    public ushort keyword_capture_token;

    [NativeTypeName("__AnonymousRecord_parser_L116_C3")]
    public _external_scanner_e__Struct external_scanner;

    [NativeTypeName("const TSStateId *")]
    public ushort* primary_state_ids;

    public unsafe partial struct _external_scanner_e__Struct
    {
        [NativeTypeName("const bool *")]
        public bool* states;

        [NativeTypeName("const TSSymbol *")]
        public ushort* symbol_map;

        [NativeTypeName("void *(*)()")]
        public delegate* unmanaged[Cdecl]<void*> create;

        [NativeTypeName("void (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void> destroy;

        [NativeTypeName("bool (*)(void *, TsLexer *, const bool *)")]
        public delegate* unmanaged[Cdecl]<void*, TsLexer*, bool*, byte> scan;

        [NativeTypeName("unsigned int (*)(void *, char *)")]
        public delegate* unmanaged[Cdecl]<void*, string, uint> serialize;

        [NativeTypeName("void (*)(void *, const char *, unsigned int)")]
        public delegate* unmanaged[Cdecl]<void*, string, uint, void> deserialize;
    }
}
