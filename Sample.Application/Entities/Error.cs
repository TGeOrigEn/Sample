namespace Sample.Application.Entities
{
    public class Error
    {
        public string Module { get; set; } = null!;

        public int ECode { get; set; }

        public string Description { get; set; } = null!;

        public override bool Equals(object? obj) =>
            obj is Error error && GetHashCode() == error.GetHashCode();

        public override int GetHashCode() =>
            HashCode.Combine(Description, Module, ECode);

        public override string ToString() =>
            $"Module: {Module}; Description: {Description}; ECode: {ECode}.";
    }
}
