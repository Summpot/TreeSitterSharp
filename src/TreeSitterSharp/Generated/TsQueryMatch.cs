namespace TreeSitterSharp.Native
{
    public unsafe partial struct TsQueryMatch
    {
        [NativeTypeName("uint32_t")]
        public uint Id;

        [NativeTypeName("uint16_t")]
        public ushort PatternIndex;

        [NativeTypeName("uint16_t")]
        public ushort CaptureCount;

        [NativeTypeName("const TsQueryCapture *")]
        public TsQueryCapture* Captures;
    }
}
