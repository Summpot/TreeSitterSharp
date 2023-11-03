namespace TreeSitterSharp.Native;

public unsafe struct TsQueryMatch
{
    public uint Id;
    
    public ushort PatternIndex;
    
    public ushort CaptureCount;
    
    public TsQueryCapture* Captures;
}
