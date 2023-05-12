namespace Sample.Application.Common.Mapping.DTO
{
    public class ServiceInfoDTO
    {
        public string AppName { get; set; } = null!;

        public string Version { get; set; } = null!;

        public DateTime DateUtc { get; set; }
    }
}
