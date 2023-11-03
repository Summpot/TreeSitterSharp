namespace TreeSitterSharp.C;
public class CParser : TreeSitterSyntaxParser
{
    public CParser() : base(CLanguageProvider.GetLanguage())
    {
    }
}
