using TreeSitterSharp.Native;

namespace TreeSitterSharp.C.Tests;

public class UnitTest1
{
    public unsafe void Test1()
    {
        TSParser* parser = Ts.parser_new();
        var language = TsC.tree_sitter_c();
        //Ts.parser_set_language(parser, language);
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
        TSTree* tree = Ts.parser_parse_string(
            parser,
            null,
            code,
            (uint)code.Length
        );
    }
}
