namespace TreeSitterSharp.C;
public class CParser : TreeSitterParser
{
    public CParser() : base(CLanguageProvider.GetLanguage())
    {
    }
}
