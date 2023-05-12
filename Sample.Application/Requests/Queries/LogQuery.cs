using MediatR;
using Sample.Application.Entities;

namespace Sample.Application.Requests.Queries
{
    public class LogQuery : IRequest<Log> { }
}
