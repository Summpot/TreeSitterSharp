namespace TreeSitterSharp.Native
{
    public partial struct TSRange
    {
        public TsPoint start_point;

        public TsPoint end_point;

        [NativeTypeName("uint32_t")]
        public uint start_byte;

        [NativeTypeName("uint32_t")]
        public uint end_byte;
    }
}
