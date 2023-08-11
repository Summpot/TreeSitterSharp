namespace TreeSitterSharp.Native
{
    public partial struct TSQueryCapture
    {
        public TSNode node;

        [NativeTypeName("uint32_t")]
        public uint index;
    }
}
