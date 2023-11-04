using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TreeSitterSharp.NodeTypesSourceGenerators;

public class NodeTypesInfo : List<NodeTypesInfo.NodeTypeInfo>
{
    public class NodeTypeInfo
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("named")]
        public bool Named { get; set; }

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
    }
}



