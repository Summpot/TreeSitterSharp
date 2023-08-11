using System.Runtime.InteropServices;

namespace TreeSitterSharp.Native
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct TSParseActionEntry
    {
        [FieldOffset(0)]
        public TSParseAction action;

        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_parser_L83_C3")]
        public _entry_e__Struct entry;

        public partial struct _entry_e__Struct
        {
            [NativeTypeName("uint8_t")]
            public byte count;

            [NativeTypeName("bool")]
            public byte reusable;
        }
    }
}
