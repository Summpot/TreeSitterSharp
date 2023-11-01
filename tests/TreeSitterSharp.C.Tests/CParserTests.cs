namespace TreeSitterSharp.C.Tests;

public class CParserTests
{
    [Fact]
    public void PrintTree()
    {
        var parser = new CParser();
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

        string expected = """
            (translation_unit (preproc_include path: (system_lib_string)) (function_definition type: (primitive_type) declarator: (function_declarator declarator: (identifier) parameters: (parameter_list (parameter_declaration type: (primitive_type) declarator: (identifier)))) body: (compound_statement (if_statement condition: (parenthesized_expression (binary_expression left: (identifier) right: (number_literal))) consequence: (compound_statement (return_statement (number_literal))) alternative: (else_clause (if_statement condition: (parenthesized_expression (binary_expression left: (identifier) right: (number_literal))) consequence: (compound_statement (return_statement (number_literal))) alternative: (else_clause (compound_statement (return_statement (binary_expression left: (call_expression function: (identifier) arguments: (argument_list (binary_expression left: (identifier) right: (number_literal)))) right: (call_expression function: (identifier) arguments: (argument_list (binary_expression left: (identifier) right: (number_literal))))))))))))))
            """;


        var tree = parser.Parse(code);
        var treeCursor = new TreeCursor(tree.Root);
        var a = treeCursor.GotoFirstChild();
        Assert.Equal(expected, tree.Root.GetSExpression());
    }
}
