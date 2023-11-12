using System.Text;
using TreeSitterSharp.Cpp;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.Cpp;

public unsafe class CppParser : Parser<CppSyntaxTree, CppSyntaxNode, CppParser>
{
    public CppParser() : base(CppLanguageProvider.GetLanguage())
    {

    }

    public override CppSyntaxTree Parse(Span<byte> code) => new(ParseCore(code));
}
