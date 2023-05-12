using AutoMapper;
using Sample.Application.Entities;

namespace Sample.Application.Requests.Commands.Handler
{
    public class CreateLogCommandHandler : RequestHandler<CreateLogCommand>
    {
        public CreateLogCommandHandler(IMapper mapper) : base(mapper) { }

        public override async Task<Log?> Handle(CreateLogCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            SaveLog(request.Log);
            return request.Log;
        }
    }
}
