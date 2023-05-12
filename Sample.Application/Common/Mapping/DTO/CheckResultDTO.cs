using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Sample.Application.Common.Mapping.DTO
{
    public class CheckResultDTO
    {
        public int Total { get; set; }

        public int Correct { get; set; }

        public int Errors { get; set; }

        [JsonPropertyName("filenames")]
        [JsonProperty(PropertyName = "filenames")]      
        public string[] FileNames { get; set; } = null!;
    }
}
