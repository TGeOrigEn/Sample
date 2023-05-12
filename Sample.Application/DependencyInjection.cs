using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Common.Mapping;
using System.Reflection;

namespace Sample.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddScoped(provider => new MapperConfiguration(configure =>
            {
                configure.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            })
            .CreateMapper());

            return services;
        }
    }
}
