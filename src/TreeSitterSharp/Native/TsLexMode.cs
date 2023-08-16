namespace TreeSitterSharp.Native;

public partial struct TsLexMode
{
    [NativeTypeName("uint16_t")]
    public ushort lex_state;

    [NativeTypeName("uint16_t")]
    public ushort external_lex_state;
}
