namespace TreeSitterSharp.Native;

public struct TsFieldMapEntry
{
    [NativeTypeName("TSFieldId")]
    public ushort field_id;

    [NativeTypeName("uint8_t")]
    public byte child_index;

    [NativeTypeName("bool")]
    public byte inherited;
}
