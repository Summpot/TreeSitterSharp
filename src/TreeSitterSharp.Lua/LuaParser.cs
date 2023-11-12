using System.Text;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.Lua;

public unsafe class LuaParser : Parser<LuaSyntaxTree, LuaSyntaxNode, LuaParser>
{
    public LuaParser() : base(LuaLanguageProvider.GetLanguage())
    {

    }

    public override LuaSyntaxTree Parse(Span<byte> code) => new(ParseCore(code));
}
