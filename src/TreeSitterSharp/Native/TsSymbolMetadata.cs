namespace TreeSitterSharp.Native;

public struct TsSymbolMetadata
{
    [NativeTypeName("bool")]
    public byte Visible;

    [NativeTypeName("bool")]
    public byte Named;

    [NativeTypeName("bool")]
    public byte Supertype;
}
