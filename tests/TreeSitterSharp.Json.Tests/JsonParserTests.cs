using System.Xml.Linq;

namespace TreeSitterSharp.Json.Tests;

public class JsonParserTests
{
    public void BasicParsing()
    {
        var parser = Parser.Create(JsonLanguageProvider.GetLanguage());
        string code = "[1, null]";
        var tree = parser.Parse(code);
        Node rootNode = tree.Root;
        Node arrayNode = rootNode.GetNamedChild(0);
        Node numberNode = arrayNode.GetNamedChild(0);

        Assert.Equal("document", rootNode.Type);
        Assert.Equal("array", arrayNode.Type);
        Assert.Equal("number", numberNode.Type);

        Assert.True(rootNode.ChildCount == 1);
        Assert.True(arrayNode.ChildCount == 5);
        Assert.True(arrayNode.NamedChildCount == 2);
        Assert.True(numberNode.ChildCount == 0);
    }
}
