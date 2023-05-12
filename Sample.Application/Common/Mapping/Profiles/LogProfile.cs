using AutoMapper;
using Newtonsoft.Json.Linq;
using Sample.Application.Entities;

namespace Sample.Application.Common.Mapping.Profiles
{
    public class LogProfile : IMappingProfile
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<JObject, Log>()
                .ForMember(destination => destination.Files, options => options.MapFrom(source => source["files"]))
                .ForMember(destination => destination.Scan, options => options.MapFrom(source => source["scan"]));

            profile.CreateMap<JToken, Log>()
                .ForMember(destination => destination.Files, options => options.MapFrom(source => source["files"]))
                .ForMember(destination => destination.Scan, options => options.MapFrom(source => source["scan"]));
        }
    }
}
