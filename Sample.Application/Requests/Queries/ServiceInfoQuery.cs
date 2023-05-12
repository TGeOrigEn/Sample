using MediatR;
using Sample.Application.Common.Mapping.DTO;
using System.Reflection;

namespace Sample.Application.Requests.Queries
{
    public class ServiceInfoQuery : IRequest<ServiceInfoDTO> 
    {
        public AssemblyName AssemblyName { get; set; } = null!;
    }
}
