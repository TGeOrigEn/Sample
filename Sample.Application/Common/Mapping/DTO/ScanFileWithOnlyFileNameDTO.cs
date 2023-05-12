using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Sample.Application.Common.Mapping.DTO
{
    public class ScanFileWithOnlyFileNameDTO
    {
        [JsonPropertyName("filename")]
        [JsonProperty(PropertyName = "filename")]
        public string FileName { get; set; } = null!;
    }
}
