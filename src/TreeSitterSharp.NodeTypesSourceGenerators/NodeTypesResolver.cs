using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.SymbolStore;
using System.Text;
using System.Xml.Linq;
using Microsoft.CodeAnalysis.FlowAnalysis;
using static TreeSitterSharp.NodeTypesSourceGenerators.NodeTypesInfo;

namespace TreeSitterSharp.NodeTypesSourceGenerators;
internal class NodeTypesResolver
{
    internal class TreeNode
    {
        private readonly HashSet<TreeNode> _children = new();

        private TreeNode(bool isRoot)
        {
            IsRoot = isRoot;
        }
        public TreeNode(TreeNode? parent, string? name) : this(false)
        {
            Parent = parent;
            Name = name;
        }

        public bool IsRoot { get; }
        public TreeNode? Parent { get; set; }
        public string? Name { get; }
        public ImmutableHashSet<TreeNode>? Children => _children.Count == 0 ? null : _children.ToImmutableHashSet();

        public static TreeNode CreateRoot()
        {
            return new(true);
        }

        public void AddChild(TreeNode node)
        {
            _children.Add(node);
        }

        public TreeNode? Search(string target)
        {
            Queue<TreeNode> queue = new();
            HashSet<TreeNode> visited = new();
            queue.Enqueue(this);
            visited.Add(this);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Name == target)
                {
                    return node;
                }
                if (node.Children is not null)
                {
                    foreach (var child in node.Children)
                    {
                        if (!visited.Contains(child))
                        {
                            queue.Enqueue(child);
                            visited.Add(child);
                        }
                    }
                }
            }
            return null;
        }
    }

    public NodeTypesResolver(NodeTypesInfo nodeTypesInfo)
    {
        Visit(nodeTypesInfo);
    }

    public Dictionary<string, string?> SubToBase { get; } = new();
    public Dictionary<string, NodeTypeInfo> AllTypes = new();

    private void Visit(NodeTypesInfo nodeTypesInfo)
    {
        var set = new HashSet<NodeTypeInfo>();
        TreeNode? root = TreeNode.CreateRoot();
        foreach (NodeTypeInfo nodeTypeInfo in nodeTypesInfo)
        {
            if (nodeTypeInfo.Subtypes is { } subtypes)
            {
                var baseNode = root.Search(nodeTypeInfo.Type);
                if (baseNode is null)
                {
                    root.AddChild(baseNode = new TreeNode(root, nodeTypeInfo.Type));
                }

                foreach (var subtype in subtypes)
                {
                    if (subtype.Named)
                    {
                        baseNode.AddChild(new TreeNode(baseNode, subtype.Type));
                    }
                }
            }
            if (nodeTypeInfo.Named)
            {
                AllTypes.Add(nodeTypeInfo.Type, nodeTypeInfo);
            }
        }
        Traverse(root);
        void Traverse(TreeNode node)
        {
            if (node.Name is not null && node.Parent is not null)
            {
                SubToBase[node.Name] = node.Parent.Name;
            }
            if (node.Children is null)
            {
                return;
            }
            foreach (TreeNode child in node.Children)
            {
                Traverse(child);
            }
        }

    }
}
