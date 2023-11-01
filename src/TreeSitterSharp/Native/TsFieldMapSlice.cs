namespace TreeSitterSharp.Native;

public struct TsFieldMapSlice
{
    [NativeTypeName("uint16_t")]
    public ushort index;

    [NativeTypeName("uint16_t")]
    public ushort length;
}
