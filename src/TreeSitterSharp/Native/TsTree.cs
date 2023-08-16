using System.Runtime.InteropServices;

namespace TreeSitterSharp.Native;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TsTree
{
    public Subtree root;
    public TsLanguage* language;
    public TsRange* included_ranges;
    public uint included_range_count;
}
