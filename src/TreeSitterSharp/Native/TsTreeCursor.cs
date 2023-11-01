namespace TreeSitterSharp.Native;

public unsafe struct TsTreeCursor
{
    public TsTree* tree;

    [NativeTypeName("const void *")]
    public void* id;

    public fixed uint context[2];
}
