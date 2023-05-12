using AutoMapper;
using Sample.Application.Common.Mapping.DTO;

namespace Sample.Application.Requests.Queries.Handlers
{
    public class ServiceInfoQueryHandler : RequestHandler<ServiceInfoQuery, ServiceInfoDTO>
    {
        public ServiceInfoQueryHandler(IMapper mapper) : base(mapper) { }

        public override async Task<ServiceInfoDTO> Handle(ServiceInfoQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);

            return new()
            {
                Version = request.AssemblyName.Version!.ToString(),
                AppName = request.AssemblyName.Name!,
                DateUtc = DateTime.UtcNow
            };
        }
    }
}
