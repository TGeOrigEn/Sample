using MediatR;
using Sample.Application.Common.Mapping.DTO;

namespace Sample.Application.Requests.Queries
{
    public class CheckResultQuery : IRequest<CheckResultDTO> { }
}
