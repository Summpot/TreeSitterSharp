using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace TreeSitterSharp.NodeTypesSourceGenerators;
internal class NodeTypesVisitor
{
    private readonly HashSet<string> _visited = new();

    public NodeTypesVisitor(NodeTypesInfo nodeTypesInfo)
    {
        Visit(nodeTypesInfo);
    }

    public Dictionary<string, string> SubToBase { get; } = new();
    public Dictionary<string, NodeTypesInfo.SubtypeElement> AllTypes = new();

    private void Visit(NodeTypesInfo nodeTypesInfo)
    {
        var set = new HashSet<NodeTypesInfo.NodeTypeInfo>();
        foreach (NodeTypesInfo.NodeTypeInfo nodeTypeInfo in nodeTypesInfo)
        {
            if (nodeTypeInfo.Subtypes is { } subtypes)
            {
                foreach (var subtype in subtypes)
                {
                    if (SubToBase.TryGetValue(subtype.Type, out string baseType))
                    {
                        if (!SubToBase.ContainsKey(baseType))
                        {
                            set.Add(nodeTypeInfo);
                        }
                        continue;
                    }
                    SubToBase.Add(subtype.Type, nodeTypeInfo.Type);
                }
            }
            else
            {
                AllTypes.Add(nodeTypeInfo.Type, nodeTypeInfo);
            }
            _visited.Add(nodeTypeInfo.Type);
        }
    }
}
