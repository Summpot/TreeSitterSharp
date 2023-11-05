namespace TreeSitterSharp.Json.Tests;

public class JsonParserTests
{
    [Fact]
    public void BasicParsing()
    {
        var parser = new JsonParser();
        string code = "[1, null]";
        var tree = parser.Parse(code);
        JsonSyntaxNode rootNode = tree.Root;
        JsonSyntaxNode arrayNode = rootNode.GetNamedChild(0);
        JsonSyntaxNode numberNode = arrayNode.GetNamedChild(0);

        Assert.Equal("document", rootNode.NodeType);
        Assert.Equal("array", arrayNode.NodeType);
        Assert.Equal("number", numberNode.NodeType);

        Assert.True(rootNode.ChildCount == 1);
        Assert.True(arrayNode.ChildCount == 5);
        Assert.True(arrayNode.NamedChildCount == 2);
        Assert.True(numberNode.ChildCount == 0);
    }

    [Fact]
    public void PrintTree()
    {
        var parser = new JsonParser();
        string code = "[1, null]";
        var tree = parser.Parse(code);
        JsonSyntaxNode rootNode = tree.Root;

        string expected = """
            (document (array (number) (null)))
            """;

        Assert.Equal(expected, rootNode.GetSExpression());
    }

}
