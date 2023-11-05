
using System.Text;

namespace TreeSitterSharp.Json;

public class JsonParser : Parser<JsonSyntaxTree, JsonSyntaxNode, JsonParser>
{
    public JsonParser() : base(JsonLanguageProvider.GetLanguage())
    {

    }

    public override JsonSyntaxTree Parse(Span<byte> code)
    {
        unsafe
        {
            return new(ParseCore(code));
        }
    }
}
