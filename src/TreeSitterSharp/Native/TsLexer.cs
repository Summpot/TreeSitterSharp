namespace TreeSitterSharp.Native;

public unsafe partial struct TsLexer
{
    [NativeTypeName("int32_t")]
    public int lookahead;

    [NativeTypeName("TSSymbol")]
    public ushort result_symbol;

    [NativeTypeName("void (*)(TsLexer *, bool)")]
    public delegate* unmanaged[Cdecl]<TsLexer*, byte, void> advance;

    [NativeTypeName("void (*)(TsLexer *)")]
    public delegate* unmanaged[Cdecl]<TsLexer*, void> mark_end;

    [NativeTypeName("uint32_t (*)(TsLexer *)")]
    public delegate* unmanaged[Cdecl]<TsLexer*, uint> get_column;

    [NativeTypeName("bool (*)(const TsLexer *)")]
    public delegate* unmanaged[Cdecl]<TsLexer*, byte> is_at_included_range_start;

    [NativeTypeName("bool (*)(const TsLexer *)")]
    public delegate* unmanaged[Cdecl]<TsLexer*, byte> eof;
}
