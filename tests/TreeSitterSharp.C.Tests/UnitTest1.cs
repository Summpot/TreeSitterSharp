using System.Runtime.CompilerServices;
using System.Xml.Linq;
using TreeSitterSharp.Native;

namespace TreeSitterSharp.C.Tests;

public class UnitTest1
{
    public unsafe void Test1()
    {
        var parser = Parser.Create(CLanguageProvider.GetLanguage());
        string code = """
            #include <stdio.h>
            
            int fibonacci(int n) {
                if (n <= 0) {
                    return 0;
                } else if (n == 1) {
                    return 1;
                } else {
                    return fibonacci(n - 1) + fibonacci(n - 2);
                }
            }
            """;
        var tree = parser.Parse(code);
        Node rootNode = tree.Root;
        Node child = rootNode.GetChild(0);
    }
}
