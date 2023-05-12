using MediatR;
using Sample.Application.Common.Mapping.DTO;

namespace Sample.Application.Requests.Queries
{
    public class ScanFilesWithOnlyFileNameQuery : IRequest<IEnumerable<ScanFileWithOnlyFileNameDTO>> 
    {
        public bool Correct { get; set; }
    }
}
