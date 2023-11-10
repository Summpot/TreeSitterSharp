using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TreeSitterSharp.NodeTypesSourceGenerators;

public class NodeTypesInfo : List<NodeTypesInfo.NodeTypeInfo>
{
    public class NodeTypeInfo : SubtypeElement
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("subtypes")]
        public List<SubtypeElement>? Subtypes { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("fields")]
        public Dictionary<string, ChildrenInfo>? Fields { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("children")]
        public ChildrenInfo? Children { get; set; }
    }
    public class ChildrenInfo
    {
        [JsonPropertyName("multiple")]
        public bool Multiple { get; set; }

        [JsonPropertyName("required")]
        public bool ChildrenRequired { get; set; }

        [JsonPropertyName("types")]
        public List<SubtypeElement>? Types { get; set; }
    }

    public class SubtypeElement
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("named")]
        public bool Named { get; set; }

        protected bool Equals(SubtypeElement other) => Type == other.Type && Named == other.Named;

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

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((SubtypeElement)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Type.GetHashCode() * 397) ^ Named.GetHashCode();
            }
        }
    }
}



