using AutoMapper;
using Sample.Application.Entities;

namespace Sample.Application.Requests.Queries.Handlers
{
    public class ScanQueryHandler : RequestHandler<ScanQuery, Scan>
    {
        public ScanQueryHandler(IMapper mapper) : base(mapper) { }

        public override async Task<Scan> Handle(ScanQuery request, CancellationToken cancellationToken) =>
            (await GetLog(cancellationToken)).Scan;
    }
}
