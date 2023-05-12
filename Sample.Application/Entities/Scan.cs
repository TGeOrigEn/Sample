namespace Sample.Application.Entities
{
    public class Scan
    {
        public DateTime ScanTime { get; set; }

        public string DataBase { get; set; } = null!;

        public string Server { get; set; } = null!;

        public int ErrorCount { get; set; }

        public override bool Equals(object? obj) =>
            obj is Scan scan && GetHashCode() == scan.GetHashCode();

        public override int GetHashCode() =>
            HashCode.Combine(Server, DataBase, ErrorCount, ScanTime);

        public override string ToString() =>
            $"Server: {Server}; DataBase: {DataBase}; ErrorCount: {ErrorCount}; ScanTime: {ScanTime}.";
    }
}
