using MediatR;
using Sample.Application.Entities;

namespace Sample.Application.Requests.Commands
{
    public class CreateLogCommand : IRequest
    {
        public Log Log { get; set; } = null!;
    }
}
