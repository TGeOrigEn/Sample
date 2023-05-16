using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

        private static void SaveLog(Log log)
        {
            var logName = Path.Combine(PathToLogs, $"{DateTime.UtcNow.ToString(DATE_TIME_FORMAT)}.json");

            if (!Directory.Exists(PathToLogs))
                Directory.CreateDirectory(PathToLogs);

            using StreamWriter streamWriter = new(logName);

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            JsonSerializer.CreateDefault(settings).Serialize(streamWriter, log);
        }
    }
}
