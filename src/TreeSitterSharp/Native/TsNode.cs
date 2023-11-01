namespace TreeSitterSharp.Native;

public unsafe struct TsNode
{
    [NativeTypeName("uint32_t[4]")]
    public fixed uint context[4];

    [NativeTypeName("const void *")]
    public void* id;

    [NativeTypeName("const Tree *")]
    public TsTree* tree;
}
