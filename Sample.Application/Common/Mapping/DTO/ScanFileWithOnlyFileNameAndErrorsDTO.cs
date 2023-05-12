using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Sample.Application.Common.Mapping.DTO
{
    public class ScanFileWithOnlyFileNameAndErrorsDTO
    {
        [JsonPropertyName("filename")]
        [JsonProperty(PropertyName = "filename")]
        public string FileName { get; set; } = null!;

        public IReadOnlyList<string> Errors { get; set; } = null!;
    }
}
