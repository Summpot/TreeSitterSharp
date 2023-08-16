namespace TreeSitterSharp.Native;

public unsafe partial struct TsLogger
{
    public void* payload;

    [NativeTypeName("void (*)(void *, TsLogType, const char *)")]
    public delegate* unmanaged[Cdecl]<void*, TsLogType, sbyte*, void> log;
}
