using AutoMapper;
using Newtonsoft.Json.Linq;
using Sample.Application.Entities;

namespace Sample.Application.Common.Mapping.Profiles
{
    public class ErrorProfile : IMappingProfile
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<JObject, Error>()
                .ForMember(destination => destination.Description, oprions => oprions.MapFrom(source => source["error"]!.ToObject<string>()))
                .ForMember(destination => destination.Module, options => options.MapFrom(source => source["module"]!.ToObject<string>()))             
                .ForMember(destination => destination.ECode, options => options.MapFrom(source => source["ecode"]!.ToObject<int>()));

            profile.CreateMap<JToken, Error>()
                .ForMember(destination => destination.Description, oprions => oprions.MapFrom(source => source["error"]!.ToObject<string>()))
                .ForMember(destination => destination.Module, options => options.MapFrom(source => source["module"]!.ToObject<string>()))      
                .ForMember(destination => destination.ECode, options => options.MapFrom(source => source["ecode"]!.ToObject<int>()));
        }
    }
}
