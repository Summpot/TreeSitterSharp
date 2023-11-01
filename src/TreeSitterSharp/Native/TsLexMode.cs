namespace TreeSitterSharp.Native;

public struct TsLexMode
{
    [NativeTypeName("uint16_t")]
    public ushort lex_state;

    [NativeTypeName("uint16_t")]
    public ushort external_lex_state;
}
