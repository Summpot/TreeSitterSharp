namespace TreeSitterSharp.C;
public class CParser : Parser
{
    public CParser() : base(CLanguageProvider.GetLanguage())
    {
    }
}
