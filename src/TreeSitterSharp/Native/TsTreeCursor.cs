namespace TreeSitterSharp.Native;

public unsafe partial struct TsTreeCursor
{
    public TsTree* tree;

    [NativeTypeName("const void *")]
    public void* id;

    public fixed uint context[2];
}
