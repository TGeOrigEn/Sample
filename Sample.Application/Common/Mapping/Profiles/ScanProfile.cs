using AutoMapper;
using Newtonsoft.Json.Linq;
using Sample.Application.Entities;

namespace Sample.Application.Common.Mapping.Profiles
{
    public class ScanProfile : IMappingProfile
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<JObject, Scan>()
                .ForMember(destination => destination.ScanTime, options => options.MapFrom(source => source["scanTime"]!.ToObject<DateTime>()))
                .ForMember(destination => destination.ErrorCount, options => options.MapFrom(source => source["errorCount"]!.ToObject<int>()))
                .ForMember(destination => destination.Server, options => options.MapFrom(source => source["server"]!.ToObject<string>()))
                .ForMember(destination => destination.DataBase, oprions => oprions.MapFrom(source => source["db"]!.ToObject<string>()));

            profile.CreateMap<JToken, Scan>()
                .ForMember(destination => destination.ScanTime, options => options.MapFrom(source => source["scanTime"]!.ToObject<DateTime>()))
                .ForMember(destination => destination.ErrorCount, options => options.MapFrom(source => source["errorCount"]!.ToObject<int>()))
                .ForMember(destination => destination.Server, options => options.MapFrom(source => source["server"]!.ToObject<string>()))
                .ForMember(destination => destination.DataBase, oprions => oprions.MapFrom(source => source["db"]!.ToObject<string>()));
        }
    }
}
