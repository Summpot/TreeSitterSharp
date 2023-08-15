namespace TreeSitterSharp.Native
{
    public unsafe partial struct TSInput
    {
        public void* payload;

        [NativeTypeName("const char *(*)(void *, uint32_t, TsPoint, uint32_t *)")]
        public delegate* unmanaged[Cdecl]<void*, uint, TsPoint, uint*, sbyte*> read;

        public TSInputEncoding encoding;
    }
}
