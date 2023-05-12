using MediatR;
using Sample.Application.Common.Mapping.DTO;

namespace Sample.Application.Requests.Queries
{
    public class ScanFileWithOnlyFileNameAndErrorsByIndexQuery : IRequest<ScanFileWithOnlyFileNameAndErrorsDTO?>
    {
        public int Index { get; set; }
    }
}
