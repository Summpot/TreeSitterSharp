namespace TreeSitterSharp.Native;

public struct TsInputEdit
{
    [NativeTypeName("uint32_t")]
    public uint start_byte;

    [NativeTypeName("uint32_t")]
    public uint old_end_byte;

    [NativeTypeName("uint32_t")]
    public uint new_end_byte;

    public Point start_point;

    public Point old_end_point;

    public Point new_end_point;
}
