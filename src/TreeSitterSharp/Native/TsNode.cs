namespace TreeSitterSharp.Native;

public unsafe partial struct TsNode
{
    [NativeTypeName("uint32_t[4]")]
    public fixed uint context[4];

    [NativeTypeName("const void *")]
    public void* id;

    [NativeTypeName("const TsTree *")]
    public TsTree* tree;
}
