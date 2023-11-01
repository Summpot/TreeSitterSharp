namespace TreeSitterSharp.Native;

public struct TsQueryCapture
{
    public TsNode Node;

    [NativeTypeName("uint32_t")]
    public uint Index;
}
