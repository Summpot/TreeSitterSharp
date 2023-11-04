using System.Text;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.C;

public unsafe class CParser : Parser
{
    public CParser() : base(CLanguageProvider.GetLanguage())
    {

    }

    public override CSyntaxTree Parse(string code)
    {
        return new CSyntaxTree(Ts.parser_parse_string(_parser, null, code, (uint)code.Length));
    }

    public override CSyntaxTree Parse(Span<byte> code, Encoding encoding)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(encoding.GetString(code));
        return new CSyntaxTree(Ts.parser_parse_string_encoding(_parser, null, bytes, (uint)bytes.Length, TsInputEncoding.TSInputEncodingUTF8));
    }
}
