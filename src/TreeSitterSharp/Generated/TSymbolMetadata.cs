namespace TreeSitterSharp.Native
{
    public partial struct TsSymbolMetadata
    {
        [NativeTypeName("bool")]
        public byte Visible;

        [NativeTypeName("bool")]
        public byte Named;

        [NativeTypeName("bool")]
        public byte Supertype;
    }
}
