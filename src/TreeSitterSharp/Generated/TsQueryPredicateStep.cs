namespace TreeSitterSharp.Native
{
    public partial struct TsQueryPredicateStep
    {
        public TsQueryPredicateStepType Type;

        [NativeTypeName("uint32_t")]
        public uint ValueId;
    }
}
