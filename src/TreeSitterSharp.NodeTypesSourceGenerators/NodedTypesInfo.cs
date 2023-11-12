using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using static TreeSitterSharp.NodeTypesSourceGenerators.NodeTypesInfo;

namespace TreeSitterSharp.NodeTypesSourceGenerators;

public partial class NodeTypesInfo : List<NodeTypeInfo>
{
    public partial class NodeTypeInfo : SubtypesInfo
    {
        [JsonPropertyName("fields")]
        public Dictionary<string, ChildrenInfo>? Fields { get; set; }

        [JsonPropertyName("children")]
        public ChildrenInfo? Children { get; set; }
    }
    
    public partial class SubtypesInfo : NodeTypeBasicInfo
    {
        [JsonPropertyName("subtypes")]
        public List<NodeTypeBasicInfo>? Subtypes { get; set; }
    }

    public partial class ChildrenInfo
    {
        [JsonPropertyName("multiple")]
        public bool Multiple { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }

        [JsonPropertyName("types")]
        public List<NodeTypeBasicInfo>? Types { get; set; }
    }
    
    public partial class NodeTypeBasicInfo
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("named")]
        public bool Named { get; set; }

        protected bool Equals(NodeTypeBasicInfo other) => Type == other.Type && Named == other.Named;

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((NodeTypeBasicInfo)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Named);
        }
    }
}



