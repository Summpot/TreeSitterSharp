
namespace TreeSitterSharp.Json;
public class JsonParser : Parser
{
    public JsonParser() : base(JsonLanguageProvider.GetLanguage())
    {
    }
}
