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
            profile.CreateMap<LogFile, ScanFileWithOnlyFileNameDTO>()
                .ForMember(destination => destination.FileName, options => options.MapFrom(source => source.FileName));

            profile.CreateMap<LogFile, ScanFileWithOnlyFileNameAndErrorsDTO>()
                .ForMember(destination => destination.FileName, options => options.MapFrom(source => source.FileName))
                .ForMember(destination => destination.Errors, options => options.MapFrom(source => source.Errors.Select(error => error.Description)));
        }
    }
}
