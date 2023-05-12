using AutoMapper;

namespace Sample.Application.Requests.Queries.Handlers
{
    public class ErrorCountQueryHandler : RequestHandler<ErrorCountQuery, int>
    {
        public ErrorCountQueryHandler(IMapper mapper) : base(mapper) { }

        public override async Task<int> Handle(ErrorCountQuery request, CancellationToken cancellationToken) =>
            (await GetLog(cancellationToken)).Scan.ErrorCount;
    }
}
