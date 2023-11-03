
namespace TreeSitterSharp.Json;
public class JsonParser : TreeSitterParser
{
    public JsonParser() : base(JsonLanguageProvider.GetLanguage())
    {
    }
}
