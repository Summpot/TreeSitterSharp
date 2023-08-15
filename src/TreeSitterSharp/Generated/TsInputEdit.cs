namespace TreeSitterSharp.Native
{
    public partial struct TSInputEdit
    {
        [NativeTypeName("uint32_t")]
        public uint start_byte;

        [NativeTypeName("uint32_t")]
        public uint old_end_byte;

        [NativeTypeName("uint32_t")]
        public uint new_end_byte;

        public TsPoint start_point;

        public TsPoint old_end_point;

        public TsPoint new_end_point;
    }
}
