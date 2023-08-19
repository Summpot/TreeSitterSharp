namespace TreeSitterSharp.Native;

public unsafe partial struct TsInput
{
    public void* payload;

    [NativeTypeName("const char *(*)(void *, uint32_t, TsPoint, uint32_t *)")]
    public delegate* unmanaged[Cdecl]<void*, uint, TsPoint, uint*, string> read;

    public TsInputEncoding encoding;
}
