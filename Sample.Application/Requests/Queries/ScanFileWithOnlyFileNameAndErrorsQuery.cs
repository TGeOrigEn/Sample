using MediatR;
using Sample.Application.Common.Mapping.DTO;

namespace Sample.Application.Requests.Queries
{
    public class ScanFileWithOnlyFileNameAndErrorsQuery : IRequest<IEnumerable<ScanFileWithOnlyFileNameAndErrorsDTO>> { }
}
