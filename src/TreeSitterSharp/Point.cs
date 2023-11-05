using System.Diagnostics;

namespace TreeSitterSharp;

[DebuggerDisplay("({Row},{Column})")]
public struct Point
{
    public uint Row;

    public uint Column;
}
