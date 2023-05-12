using AutoMapper;
using Sample.Application.Common.Mapping.DTO;

namespace Sample.Application.Requests.Queries.Handlers
{
    public class CheckResultQueryHandler : RequestHandler<CheckResultQuery, CheckResultDTO>
    {
        public CheckResultQueryHandler(IMapper mapper) : base(mapper) { }

        public override async Task<CheckResultDTO> Handle(CheckResultQuery request, CancellationToken cancellationToken)
        {
            var files = (await GetLog(cancellationToken)).Files;

            var groupByResult = files
                .GroupBy(file => file.Result)
                .ToDictionary(g => g.Key, g => g.ToArray());

            groupByResult.TryGetValue(true, out var correct);
            groupByResult.TryGetValue(false, out var errors);

            var total = files.Where(file => file.FileName.ToLower().StartsWith("query_")).ToArray();

            var filenames = errors?.Select(file => file.FileName).ToArray() ?? Array.Empty<string>();

            return new CheckResultDTO()
            {
                Correct = correct?.Length ?? 0,
                Errors = errors?.Length ?? 0,
                FileNames = filenames,
                Total = total.Length
            };
        }
    }
}
