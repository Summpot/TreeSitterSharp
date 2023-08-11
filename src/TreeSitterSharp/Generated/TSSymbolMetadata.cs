namespace TreeSitterSharp.Native
{
    public partial struct TSSymbolMetadata
    {
        [NativeTypeName("bool")]
        public byte visible;

        [NativeTypeName("bool")]
        public byte named;

        [NativeTypeName("bool")]
        public byte supertype;
    }
}
