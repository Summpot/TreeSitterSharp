namespace TreeSitterSharp.Native;

public unsafe struct TsInput
{
    public void* payload;

    [NativeTypeName("const char *(*)(void *, uint32_t, TSPoint, uint32_t *)")]
    public delegate* unmanaged[Cdecl]<void*, uint, Point, uint*, string> read;

    public TsInputEncoding encoding;
}
