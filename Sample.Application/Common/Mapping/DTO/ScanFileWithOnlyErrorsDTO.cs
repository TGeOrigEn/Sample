namespace Sample.Application.Common.Mapping.DTO
{
    public class ScanFileWithOnlyErrorsDTO
    {
        public string FileName { get; set; } = null!;

        public IReadOnlyList<string> Errors { get; set; } = null!;
    }
}
