using System.Runtime.InteropServices;

namespace TreeSitterSharp.Native;

[StructLayout(LayoutKind.Explicit)]
public partial struct TsParseAction
{
    [FieldOffset(0)]
    [NativeTypeName("__AnonymousRecord_parser_L60_C3")]
    public _shift_e__Struct shift;

    [FieldOffset(0)]
    [NativeTypeName("__AnonymousRecord_parser_L66_C3")]
    public _reduce_e__Struct reduce;

    [FieldOffset(0)]
    [NativeTypeName("uint8_t")]
    public byte type;

    public struct _shift_e__Struct
    {
        [NativeTypeName("uint8_t")]
        public byte type;

        [NativeTypeName("TSStateId")]
        public ushort state;

        [NativeTypeName("bool")]
        public byte extra;

        [NativeTypeName("bool")]
        public byte repetition;
    }

    public struct _reduce_e__Struct
    {
        [NativeTypeName("uint8_t")]
        public byte type;

        [NativeTypeName("uint8_t")]
        public byte child_count;

        [NativeTypeName("TSSymbol")]
        public ushort symbol;

        [NativeTypeName("int16_t")]
        public short dynamic_precedence;

        [NativeTypeName("uint16_t")]
        public ushort production_id;
    }
}
