using AutoMapper;
using Sample.Application.Common.Mapping.DTO;

namespace Sample.Application.Requests.Queries.Handlers
{
    public class ScanFileWithOnlyFileNameAndErrorsByIndexQueryHandler :
        RequestHandler<ScanFileWithOnlyFileNameAndErrorsByIndexQuery, ScanFileWithOnlyFileNameAndErrorsDTO?>
    {
        public ScanFileWithOnlyFileNameAndErrorsByIndexQueryHandler(IMapper mapper) : base(mapper) { }

        public override async Task<ScanFileWithOnlyFileNameAndErrorsDTO?> Handle(
            ScanFileWithOnlyFileNameAndErrorsByIndexQuery request,
            CancellationToken cancellationToken)
        {
            var files = (await GetLog(cancellationToken)).Files
                .Where(file => file.Result == false).ToArray();

            if (files.Length <= request.Index) return null;
            return mapper.Map<ScanFileWithOnlyFileNameAndErrorsDTO>(files[request.Index]);
        }
    }
}
