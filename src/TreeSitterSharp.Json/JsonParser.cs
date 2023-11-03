
namespace TreeSitterSharp.Json;
public class JsonParser : TreeSitterSyntaxParser
{
    public JsonParser() : base(JsonLanguageProvider.GetLanguage())
    {
    }
}
