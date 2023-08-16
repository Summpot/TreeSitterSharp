using System.Runtime.InteropServices;

namespace TreeSitterSharp.Native;

[StructLayout(LayoutKind.Sequential)]
public struct TsPoint
{
    [NativeTypeName("uint32_t")]
    public uint Row;

    [NativeTypeName("uint32_t")]
    public uint Column;
}
