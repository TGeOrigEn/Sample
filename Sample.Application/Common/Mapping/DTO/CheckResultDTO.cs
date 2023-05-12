namespace Sample.Application.Common.Mapping.DTO
{
    public class CheckResultDTO
    {
        public int Total { get; set; }

        public int Correct { get; set; }

        public int Errors { get; set; }

        public string[] FileNames { get; set; } = null!;
    }
}
