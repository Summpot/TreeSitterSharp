namespace TreeSitterSharp.Native;

public unsafe struct TsLogger
{
    public void* payload;

    [NativeTypeName("void (*)(void *, TsLogType, const char *)")]
    public delegate* unmanaged[Cdecl]<void*, TsLogType, string, void> log;
}
