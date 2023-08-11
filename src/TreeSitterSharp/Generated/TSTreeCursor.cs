namespace TreeSitterSharp.Native
{
    public unsafe partial struct TSTreeCursor
    {
        [NativeTypeName("const void *")]
        public void* tree;

        [NativeTypeName("const void *")]
        public void* id;

        [NativeTypeName("uint32_t[2]")]
        public fixed uint context[2];
    }
}
