using System.Text;
using System.Text.Json;
using Humanizer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static TreeSitterSharp.NodeTypesSourceGenerators.NodeTypesInfo;

namespace TreeSitterSharp.NodeTypesSourceGenerators;

[Generator]
internal class NodeTypesGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {

        var languageProvider = context.SyntaxProvider.ForAttributeWithMetadataName(
            "TreeSitterSharp.LanguageNameAttribute", (node, _) => node is ClassDeclarationSyntax,
            (syntaxContext, _) => syntaxContext).Collect();

        var source = context.AdditionalTextsProvider.Combine(context.AnalyzerConfigOptionsProvider).Where(t =>
                t.Right.GetOptions(t.Left).TryGetValue("build_metadata.AdditionalFiles.SourceItemGroup",
                    out string? sourceItemGroup) && sourceItemGroup == "NodeTypesSchema" &&
                t.Left.Path.EndsWith(".json"))
            .Select((t, _) => t.Left).Collect();

        context.RegisterPostInitializationOutput((initializationContext =>
        {
            string attributeSourceText = """
            namespace TreeSitterSharp;

            [AttributeUsage(AttributeTargets.Class)]
            public class LanguageNameAttribute : System.Attribute
            {
                public LanguageNameAttribute(string name)
                {
                }
            }
            
            """;
            initializationContext.AddSource("LanguageNameAttribute.cs", attributeSourceText);
        }));

        context.RegisterSourceOutput(source.Combine(languageProvider), (spc, input) =>
        {
            var compilationUnit = CompilationUnit();

            if (input.Right.IsDefaultOrEmpty)
            {
                return;
            }
            var languageNameAttributeSyntaxContext = input.Right.SingleOrDefault();
            string? languageName = languageNameAttributeSyntaxContext.Attributes.SingleOrDefault()?.GetConstructorArgument<string>(0);
            compilationUnit =
                compilationUnit
                    .AddUsings(UsingDirective(IdentifierName("System.Linq"))
                        .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)),
                        UsingDirective(IdentifierName("System.Collections.Immutable"))
                            .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)))
                    .AddMembers(FileScopedNamespaceDeclaration(IdentifierName($"TreeSitterSharp.{languageName}")));
            foreach (AdditionalText nodeTypesText in input.Left)
            {
                var nodeTypesInfo = JsonSerializer.Deserialize<NodeTypesInfo>(nodeTypesText.GetText()!.ToString());
                if (nodeTypesInfo is null)
                {
                    continue;
                }
                var resolver = new NodeTypesResolver(nodeTypesInfo);
                foreach (KeyValuePair<string, NodeTypeInfo> typeInfo in resolver.AllTypes)
                {
                    string className = typeInfo.Key.Pascalize();
                    string grammarType = typeInfo.Key;
                    resolver.SubToBase.TryGetValue(typeInfo.Key, out string? baseType);
                    baseType = baseType?.Pascalize();
                    baseType ??= $"global::TreeSitterSharp.{languageName}.{languageName}SyntaxNode";
                    var classDeclaration = ClassDeclaration(Identifier(className))
                        .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.UnsafeKeyword),
                            Token(SyntaxKind.PartialKeyword))
                        .AddBaseListTypes(SimpleBaseType(IdentifierName(baseType)))
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
                    if (typeInfo.Value.Fields is { } fields)
                    {
                        foreach (var kvp in fields)
                        {
                            string fieldName = kvp.Key;
                            var childrenInfo = kvp.Value;
                            var type = childrenInfo.Types!.FirstOrDefault(_ => _.Named);
                            if (type is null || type.Type.StartsWith("_"))
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
                                                IdentifierName("node_child_by_field_name")), ArgumentList()
                                                .AddArguments(Argument(IdentifierName("_node")),
                                                    Argument(LiteralExpression(SyntaxKind.StringLiteralExpression,
                                                        Literal(fieldName))), Argument(LiteralExpression(
                                                        SyntaxKind.NumericLiteralExpression,
                                                        Literal(fieldName.Length))))))), null)))
                                    .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
                        }
                    }

                    if (typeInfo.Value.Children is { Types: { } types } children)
                    {
                        //if (children.Multiple)
                        //{
                        foreach (NodeTypeBasicInfo type in types)
                        {
                            if ((!type.Named) || type.Type.StartsWith("_"))
                            {
                                continue;
                            }

                            string? typeName = type.Type.Pascalize();
                            classDeclaration = classDeclaration.AddMembers(
                                PropertyDeclaration(
                                        GenericName("global::System.Collections.Immutable.ImmutableArray")
                                            .AddTypeArgumentListArguments(
                                                IdentifierName(typeName)),
                                        type.Type.Pascalize().Pluralize())
                                    .AddModifiers(Token(SyntaxKind.PublicKeyword))
                                    .WithExpressionBody(ArrowExpressionClause(
                                        InvocationExpression(
                                            MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                InvocationExpression(
                                                    MemberAccessExpression(
                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                        IdentifierName("Children"),
                                                        GenericName(Identifier("OfType"))
                                                            .AddTypeArgumentListArguments(
                                                                IdentifierName(typeName)))),
                                                IdentifierName("ToImmutableArray")))))
                                    .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
                        }
                        //}
                        //else
                        //{
                        //    // We can't be sure if Types always has only one element when Multiple is false.
                        //    foreach (NodeTypeBasicInfo type in types)
                        //    {
                        //        if (!type.Named)
                        //        {
                        //            continue;
                        //        }

                        //        string? typeName = type.Type.Pascalize();
                        //        classDeclaration = classDeclaration.AddMembers(
                        //            PropertyDeclaration(IdentifierName(typeName),
                        //                    type.Type.Pascalize())
                        //                .AddModifiers(Token(SyntaxKind.PublicKeyword))
                        //                .WithExpressionBody(ArrowExpressionClause(
                        //                    InvocationExpression(
                        //                        MemberAccessExpression(
                        //                            SyntaxKind.SimpleMemberAccessExpression,
                        //                            InvocationExpression(
                        //                                MemberAccessExpression(
                        //                                    SyntaxKind.SimpleMemberAccessExpression,
                        //                                    IdentifierName("Children"),
                        //                                    GenericName(Identifier("OfType"))
                        //                                        .AddTypeArgumentListArguments(
                        //                                            IdentifierName(typeName)))),
                        //                            IdentifierName("SingleOrDefault")))))
                        //                .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
                        //    }
                        //}
                    }
                    compilationUnit = compilationUnit.AddMembers(classDeclaration);
                }
                var switchStatement = SwitchStatement(InvocationExpression(
                    MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName("global::TreeSitterSharp.Native.Ts"), IdentifierName("node_grammar_type")),
                    ArgumentList().AddArguments(Argument(IdentifierName("node")))));
                foreach (KeyValuePair<string, NodeTypeInfo> typeInfo in resolver.AllTypes)
                {
                    switchStatement = switchStatement.AddSections(SwitchSection()
                        .AddLabels(CaseSwitchLabel(LiteralExpression(SyntaxKind.StringLiteralExpression,
                            Literal(typeInfo.Key))))
                        .AddStatements(ReturnStatement(ObjectCreationExpression(Token(SyntaxKind.NewKeyword),
                            IdentifierName(typeInfo.Key.Pascalize()),
                            ArgumentList().AddArguments(Argument(IdentifierName("node"))), null))));
                }
                switchStatement = switchStatement.AddSections(SwitchSection().AddLabels(DefaultSwitchLabel())
                    .AddStatements(ReturnStatement(ObjectCreationExpression(Token(SyntaxKind.NewKeyword),
                        IdentifierName($"{languageName}SyntaxNode"),
                        ArgumentList().AddArguments(Argument(IdentifierName("node"))), null))));
                compilationUnit = compilationUnit.AddMembers(ClassDeclaration($"{languageName}SyntaxNode")
                    .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.PartialKeyword))
                    .AddMembers(MethodDeclaration(IdentifierName($"{languageName}SyntaxNode"), "Create")
                        .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword), Token(SyntaxKind.PartialKeyword))
                        .AddParameterListParameters(Parameter(Identifier("node")).WithType(IdentifierName("global::TreeSitterSharp.Native.TsNode")))
                        .AddBodyStatements(switchStatement)));

                spc.AddSource("NodeTypes.g.cs", compilationUnit.NormalizeWhitespace().GetText(Encoding.UTF8));
            }
        });
    }
}
