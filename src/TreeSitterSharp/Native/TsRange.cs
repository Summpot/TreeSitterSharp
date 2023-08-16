namespace TreeSitterSharp.Native;

public partial struct TsRange
{
    public TsPoint start_point;

    public TsPoint end_point;
    
    public uint start_byte;
    
    public uint end_byte;
}
