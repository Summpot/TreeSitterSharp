namespace TreeSitterSharp.Native
{
    public partial struct TSPoint
    {
        [NativeTypeName("uint32_t")]
        public uint row;

        [NativeTypeName("uint32_t")]
        public uint column;
    }
}
