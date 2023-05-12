using AutoMapper;
using Sample.Application.Entities;

namespace Sample.Application.Requests.Queries.Handlers
{
    public class LogQueryHandler : RequestHandler<LogQuery, Log>
    {
        public LogQueryHandler(IMapper mapper) : base(mapper) { }

        public override async Task<Log> Handle(LogQuery request, CancellationToken cancellationToken) =>
            await GetLog(cancellationToken);
    }
}
