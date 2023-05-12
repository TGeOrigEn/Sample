using MediatR;
using Sample.Application.Entities;

namespace Sample.Application.Requests.Queries
{
    public class ScanQuery : IRequest<Scan> { }
}
