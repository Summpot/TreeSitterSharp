using System.Runtime.InteropServices;

namespace TreeSitterSharp.Native;

[StructLayout(LayoutKind.Explicit)]
public partial struct TsParseActionEntry
{
    [FieldOffset(0)]
    public TsParseAction action;

    [FieldOffset(0)]
    [NativeTypeName("__AnonymousRecord_parser_L83_C3")]
    public EntryEStruct entry;

    public partial struct EntryEStruct
    {
        [NativeTypeName("uint8_t")]
        public byte Count;

        [NativeTypeName("bool")]
        public byte Reusable;
    }
}
