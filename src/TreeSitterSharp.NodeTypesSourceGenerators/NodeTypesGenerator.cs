using System.Text;
using System.Text.Json;
using Humanizer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

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

                var subtypeLookup = new Dictionary<string, Stack<string>>();
                var grammarLookup = new Dictionary<string, string>();
                var visitor = new NodeTypesVisitor(nodeTypesInfo);
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
                        grammarLookup.Add(grammarType, className);
                        var classDeclaration = ClassDeclaration(Identifier(className))
                            .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.UnsafeKeyword),
                                Token(SyntaxKind.PartialKeyword))
                            .If(nodeTypeInfo.Type.StartsWith("_") || !subtypeLookup.ContainsKey(nodeTypeInfo.Type), _ =>
                                _.AddBaseListTypes(
                                    SimpleBaseType(IdentifierName($"global::TreeSitterSharp.{languageName}.{languageName}SyntaxNode"))))
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
                                                    IdentifierName("node_child_by_field_name")), ArgumentList()
                                                    .AddArguments(Argument(IdentifierName("_node")),
                                                        Argument(LiteralExpression(SyntaxKind.StringLiteralExpression,
                                                            Literal(fieldName))), Argument(LiteralExpression(
                                                            SyntaxKind.NumericLiteralExpression,
                                                            Literal(fieldName.Length))))))), null)))
                                        .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
                            }
                        }

                        if (nodeTypeInfo.Children is { } children)
                        {
                            if (children.Types is { } types)
                            {
                                if (children.Multiple)
                                {
                                    foreach (NodeTypesInfo.SubtypeElement type in types)
                                    {
                                        if (!type.Named)
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
                                }
                                else
                                {
                                    // We can't be sure if Types always has only one element when Multiple is false.
                                    foreach (NodeTypesInfo.SubtypeElement type in types)
                                    {
                                        if (!type.Named)
                                        {
                                            continue;
                                        }
                                        string? typeName = type.Type.Pascalize();
                                        classDeclaration = classDeclaration.AddMembers(
                                            PropertyDeclaration(IdentifierName(typeName),
                                                    type.Type.Pascalize())
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
                                                            IdentifierName("SingleOrDefault")))))
                                                .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
                                    }
                                }
                            }
                        }
                        compilationUnit = compilationUnit.AddMembers(classDeclaration);


                    }
                }

                var switchStatement = SwitchStatement(InvocationExpression(
                    MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName("global::TreeSitterSharp.Native.Ts"), IdentifierName("node_grammar_type")),
                    ArgumentList().AddArguments(Argument(IdentifierName("node")))));
                foreach (KeyValuePair<string, string> kvp in grammarLookup)
                {
                    switchStatement = switchStatement.AddSections(SwitchSection()
                        .AddLabels(CaseSwitchLabel(LiteralExpression(SyntaxKind.StringLiteralExpression,
                            Literal(kvp.Key))))
                        .AddStatements(ReturnStatement(ObjectCreationExpression(Token(SyntaxKind.NewKeyword),
                            IdentifierName(kvp.Key.Pascalize()),
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
