namespace Sample.Application.Entities
{
    public class LogFile
    {
        public string FileName { get; set; } = null!;

        public bool Result { get; set; }

        public IReadOnlyList<Error> Errors { get; set; } = Array.Empty<Error>();

        public DateTime ScanTime { get; set; }

        public override bool Equals(object? obj) =>
            obj is LogFile file && GetHashCode() == file.GetHashCode();

        public override int GetHashCode() =>
            HashCode.Combine(FileName, Result, ScanTime, Errors);

        public override string ToString() =>
            $"FileName: {FileName}; Result: {Result}; ScanTime: {ScanTime}.";
    }
}
