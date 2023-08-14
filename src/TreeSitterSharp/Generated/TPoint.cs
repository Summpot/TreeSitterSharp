namespace TreeSitterSharp.Native
{
    public partial struct TsPoint
    {
        [NativeTypeName("uint32_t")]
        public uint Row;

        [NativeTypeName("uint32_t")]
        public uint Column;
    }
}
