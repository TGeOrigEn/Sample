using AutoMapper;
using Sample.Application.Common.Mapping.DTO;

namespace Sample.Application.Requests.Queries.Handlers
{
    public class ScanFilesWithOnlyFileNameQueryHandler : RequestHandler<ScanFilesWithOnlyFileNameQuery, IEnumerable<ScanFileWithOnlyFileNameDTO>>
    {
        public ScanFilesWithOnlyFileNameQueryHandler(IMapper mapper) : base(mapper) { }

        public async override Task<IEnumerable<ScanFileWithOnlyFileNameDTO>> Handle(ScanFilesWithOnlyFileNameQuery request, CancellationToken cancellationToken)
        {
            var files = (await GetLog(cancellationToken)).Files.Where(file => file.Result == request.Correct);
            return mapper.Map<IEnumerable<ScanFileWithOnlyFileNameDTO>>(files);
        }
    }
}
