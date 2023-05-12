using AutoMapper;
using Sample.Application.Common.Mapping.DTO;

namespace Sample.Application.Requests.Queries.Handlers
{
    public class ScanFileWithOnlyFileNameAndErrorsQueryHandler : RequestHandler<ScanFileWithOnlyFileNameAndErrorsQuery,
        IEnumerable<ScanFileWithOnlyFileNameAndErrorsDTO>>
    {
        public ScanFileWithOnlyFileNameAndErrorsQueryHandler(IMapper mapper) : base(mapper) { }

        public override async Task<IEnumerable<ScanFileWithOnlyFileNameAndErrorsDTO>> Handle(
            ScanFileWithOnlyFileNameAndErrorsQuery request,
            CancellationToken cancellationToken)
        {
            var files = (await GetLog(cancellationToken)).Files.Where(file => file.Result == false);
            return mapper.Map<IEnumerable<ScanFileWithOnlyFileNameAndErrorsDTO>>(files);
        }
    }
}
