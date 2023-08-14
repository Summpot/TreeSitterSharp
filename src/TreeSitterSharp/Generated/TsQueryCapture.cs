namespace TreeSitterSharp.Native
{
    public partial struct TsQueryCapture
    {
        public TsNode Node;

        [NativeTypeName("uint32_t")]
        public uint Index;
    }
}
