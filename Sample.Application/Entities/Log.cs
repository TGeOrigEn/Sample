namespace Sample.Application.Entities
{
    public class Log
    {
        public Scan Scan { get; set; } = null!;

        public IReadOnlyList<LogFile> Files { get; set; } = Array.Empty<LogFile>();

        public override bool Equals(object? obj) =>
            obj is Log log && GetHashCode() == log.GetHashCode();

        public override int GetHashCode() =>
            HashCode.Combine(Files, Scan);
    }
}
