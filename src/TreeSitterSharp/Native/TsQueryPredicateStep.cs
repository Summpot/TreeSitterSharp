namespace TreeSitterSharp.Native;

public struct TsQueryPredicateStep
{
    public TsQueryPredicateStepType Type;

    [NativeTypeName("uint32_t")]
    public uint ValueId;
}
