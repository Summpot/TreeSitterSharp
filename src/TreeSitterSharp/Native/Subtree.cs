using System.Runtime.InteropServices;

namespace TreeSitterSharp.Native;

[StructLayout(LayoutKind.Sequential)]
public struct Subtree
{
    public bool is_inline;
    public bool visible;
    public bool named;
    public bool extra;
    public bool has_changes;
    public bool is_missing1;
    public bool is_keyword;
    public byte symbol;
    public byte parse_state;
    public byte padding_columns;
    public byte padding_rows;
    public byte lookahead_bytes;
    public byte padding_bytes;
    public byte size_bytes;
}
