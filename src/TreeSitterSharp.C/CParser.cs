using System.Text;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.C;

public unsafe class CParser : Parser<CSyntaxTree, CSyntaxNode, CParser>
{
    public CParser() : base(CLanguageProvider.GetLanguage())
    {

    }

    public override CSyntaxTree Parse(Span<byte> code) => new(ParseCore(code));
}
