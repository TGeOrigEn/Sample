using AutoMapper;
using Newtonsoft.Json.Linq;
using Sample.Application.Common.Mapping.DTO;
using Sample.Application.Entities;

namespace Sample.Application.Common.Mapping.Profiles
{
    public class LogFileProfile : IMappingProfile
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<JObject, LogFile>()
                .ForMember(destination => destination.ScanTime, options => options.MapFrom(source => source["scantime"]!.ToObject<DateTime>()))
                .ForMember(destination => destination.FileName, options => options.MapFrom(source => source["filename"]!.ToObject<string>()))
                .ForMember(destination => destination.Result, oprions => oprions.MapFrom(source => source["result"]!.ToObject<bool>()))
                .ForMember(destination => destination.Errors, options => options.MapFrom(source => source["errors"]));

            profile.CreateMap<JToken, LogFile>()
                .ForMember(destination => destination.ScanTime, options => options.MapFrom(source => source["scantime"]!.ToObject<DateTime>()))
                .ForMember(destination => destination.FileName, options => options.MapFrom(source => source["filename"]!.ToObject<string>()))
                .ForMember(destination => destination.Result, oprions => oprions.MapFrom(source => source["result"]!.ToObject<bool>()))
                .ForMember(destination => destination.Errors, options => options.MapFrom(source => source["errors"]));

            profile.CreateMap<LogFile, ScanFileWithOnlyFileNameDTO>()
                .ForMember(destination => destination.FileName, options => options.MapFrom(source => source.FileName));

            profile.CreateMap<LogFile, ScanFileWithOnlyErrorsDTO>()
                .ForMember(destination => destination.FileName, options => options.MapFrom(source => source.FileName))
                .ForMember(destination => destination.Errors, options => options.MapFrom(source => source.Errors.Select(error => error.Description)));
        }
    }
}
