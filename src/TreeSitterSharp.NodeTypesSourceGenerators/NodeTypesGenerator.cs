using System.Text;
using System.Text.Json;
using Humanizer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace TreeSitterSharp.NodeTypesSourceGenerators;

[Generator]
internal class NodeTypesGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var source = context.AdditionalTextsProvider.Combine(context.AnalyzerConfigOptionsProvider).Where(t =>
                t.Right.GetOptions(t.Left).TryGetValue("build_metadata.AdditionalFiles.SourceItemGroup",
                    out string? sourceItemGroup) && sourceItemGroup == "NodeTypesSchema" &&
                t.Left.Path.EndsWith(".json"))
            .Select((t, _) => t.Left).Collect();

        context.RegisterSourceOutput(source, (spc, texts) =>
        {
            var compilationUnit = CompilationUnit();
            foreach (AdditionalText nodeTypesText in texts)
            {

                var nodeTypesInfo = JsonSerializer.Deserialize<NodeTypesInfo>(nodeTypesText.GetText().ToString());
                if (nodeTypesInfo is null)
                {
                    continue;
                }
                var subtypeLookup = new Dictionary<string, Stack<string>>();
                foreach (NodeTypesInfo.NodeTypeInfo nodeTypeInfo in nodeTypesInfo)
                {
                    if (nodeTypeInfo.Subtypes is { } subtypes)
                    {
                        foreach (var subtype in subtypes)
                        {
                            if (subtypeLookup.TryGetValue(subtype.Type, out var stack))
                            {
                                stack.Push(nodeTypeInfo.Type);
                                continue;
                            }
                            subtypeLookup.Add(subtype.Type, new Stack<string>(new[] { nodeTypeInfo.Type }));
                        }
                    }
                    if (nodeTypeInfo.Named)
                    {
                        string className = nodeTypeInfo.Type.Pascalize();
                        string grammarType = nodeTypeInfo.Type;
                        var classDeclaration = ClassDeclaration(Identifier(className))
                            .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.UnsafeKeyword),
                                Token(SyntaxKind.PartialKeyword))
                            .If(nodeTypeInfo.Type.StartsWith("_") || !subtypeLookup.ContainsKey(nodeTypeInfo.Type), _ => _.AddBaseListTypes(
                                SimpleBaseType(IdentifierName("global::TreeSitterSharp.C.CSyntaxNode"))))
                            .If(subtypeLookup.TryGetValue(nodeTypeInfo.Type, out var stack) && stack.Count > 0,
                                _ => _.AddBaseListTypes(SimpleBaseType(IdentifierName(stack!.Pop().Pascalize()))))
                            .AddMembers(ConstructorDeclaration(className)
                                .AddModifiers(Token(SyntaxKind.ProtectedKeyword), Token(SyntaxKind.InternalKeyword))
                                .AddParameterListParameters(Parameter(Identifier("node"))
                                    .WithType(IdentifierName("global::TreeSitterSharp.Native.TsNode")))
                                .WithInitializer(ConstructorInitializer(SyntaxKind.BaseConstructorInitializer)
                                    .AddArgumentListArguments(Argument(IdentifierName("node"))))
                                .AddBodyStatements())
                            .AddMembers(
                                PropertyDeclaration(PredefinedType(Token(SyntaxKind.StringKeyword)), "GrammarType")
                                    .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.OverrideKeyword))
                                    .WithExpressionBody(ArrowExpressionClause(
                                        LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(grammarType))))
                                    .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
                        if (nodeTypeInfo.Fields is not null)
                        {
                            foreach (var kvp in nodeTypeInfo.Fields)
                            {
                                string fieldName = kvp.Key;
                                var childrenInfo = kvp.Value;
                                var type = childrenInfo.Types!.FirstOrDefault(_ => _.Named);
                                if (type is null)
                                {
                                    continue;
                                }

                                classDeclaration = classDeclaration.AddMembers(
                                    PropertyDeclaration(IdentifierName(type.Type.Pascalize()),
                                            fieldName.Pascalize())
                                        .AddModifiers(Token(SyntaxKind.PublicKeyword))
                                        .WithExpressionBody(ArrowExpressionClause(ObjectCreationExpression(
                                            Token(SyntaxKind.NewKeyword),
                                            IdentifierName(type.Type.Pascalize()),
                                            ArgumentList().AddArguments(Argument(InvocationExpression(
                                                MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                                                    IdentifierName("global::TreeSitterSharp.Native.Ts"),
                                                    IdentifierName("node_child_by_field_name")), ArgumentList().AddArguments(Argument(IdentifierName("_node")),
                                                    Argument(LiteralExpression(SyntaxKind.StringLiteralExpression,
                                                        Literal(fieldName))), Argument(LiteralExpression(SyntaxKind.NumericLiteralExpression,
                                                        Literal(fieldName.Length))))))), null)))
                                        .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
                            }
                        }
                        compilationUnit = compilationUnit.AddMembers(classDeclaration);
                    }
                }
            }
            spc.AddSource("NodeTypes.g.cs", compilationUnit.NormalizeWhitespace().GetText(Encoding.UTF8));
        });
    }
}
