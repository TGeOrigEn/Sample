using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Sample.Application.Entities
{
    public class LogFile
    {
        [JsonPropertyName("filename")]
        [JsonProperty(PropertyName = "filename")]
        public string FileName { get; set; } = null!;

        public bool Result { get; set; }

        public IReadOnlyList<Error> Errors { get; set; } = Array.Empty<Error>();

        [JsonPropertyName("scantime")]
        [JsonProperty(PropertyName = "scantime")]
        public DateTime ScanTime { get; set; }

        public override bool Equals(object? obj) =>
            obj is LogFile file && GetHashCode() == file.GetHashCode();

        public override int GetHashCode() =>
            HashCode.Combine(FileName, Result, ScanTime, Errors);

        public override string ToString() =>
            $"FileName: {FileName}; Result: {Result}; ScanTime: {ScanTime}.";
    }
}
