namespace TreeSitterSharp.Json.Tests;

public class JsonParserTests
{
    [Fact]
    public void BasicParsing()
    {
        var parser = new JsonParser();
        string code = "[1, null]";
        var tree = parser.Parse(code);
        TreeSitterSyntaxNode rootNode = tree.Root;
        TreeSitterSyntaxNode arrayNode = rootNode.GetNamedChild(0);
        TreeSitterSyntaxNode numberNode = arrayNode.GetNamedChild(0);

        Assert.Equal("document", rootNode.Type);
        Assert.Equal("array", arrayNode.Type);
        Assert.Equal("number", numberNode.Type);

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
        TreeSitterSyntaxNode rootNode = tree.Root;

        string expected = """
            (document (array (number) (null)))
            """;

        Assert.Equal(expected, rootNode.GetSExpression());
    }

}
