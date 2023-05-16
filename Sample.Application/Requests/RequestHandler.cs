using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sample.Application.Entities;
using System.Globalization;

namespace Sample.Application.Requests
{
    public abstract class RequestHandler
    {
        protected static string PathToData => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "data.json");

        protected static string PathToLogs => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        protected const string DATE_TIME_FORMAT = "dd-MM-yyyy_HH-mm-ss";

        protected readonly IMapper mapper;

        protected RequestHandler(IMapper mapper) => this.mapper = mapper;

        private static DateTime ParseToDateTime(FileInfo file, string extension)
        {
            var fileName = file.Name[..^extension.Length];
            var dateTime = DateTime.ParseExact(fileName, DATE_TIME_FORMAT, CultureInfo.InvariantCulture);
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }

        protected async Task<Log> GetLog(CancellationToken cancellationToken)
        {
            const string extension = ".json";

            string path;

            if (!Directory.Exists(PathToLogs))
                Directory.CreateDirectory(PathToLogs);

            var logs = Directory.GetFiles(PathToLogs)
                .Where(path => Path.GetExtension(path) == extension)
                .Select(path => new FileInfo(path))
                .ToArray();

            if (logs.Any())
            {
                var dates = logs.Select(log => ParseToDateTime(log, extension)).ToList();
                var min = dates.MinBy(date => DateTime.UtcNow - date);
                path = logs[dates.IndexOf(min)].FullName;
            }
            else
                path = PathToData;

            var file = await File.ReadAllTextAsync(path, cancellationToken);

            return JsonConvert.DeserializeObject<Log>(file)
                ?? throw new InvalidCastException($"Failed to convert file by path '{path}' to Log.");
        }

        protected static void SaveLog(Log log)
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

    public abstract class RequestHandler<TRequest, TResponse> : RequestHandler, IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected RequestHandler(IMapper mapper) : base(mapper) { }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class RequestHandler<TRequest> : RequestHandler, IRequestHandler<TRequest> where TRequest : IRequest
    {
        protected RequestHandler(IMapper mapper) : base(mapper) { }

        public abstract Task Handle(TRequest request, CancellationToken cancellationToken);
    }
}
