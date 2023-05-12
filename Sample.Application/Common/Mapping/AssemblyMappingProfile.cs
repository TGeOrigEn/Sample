using AutoMapper;
using System.Reflection;

namespace Sample.Application.Common.Mapping
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingFromAssembly(assembly);

        private void ApplyMappingFromAssembly(Assembly assembly) => assembly.GetExportedTypes()
            .Where(IsAssignableFromMappingProfile).ToList()
            .ForEach(InvokeMapping);

        private static bool IsAssignableFromMappingProfile(Type type) =>
            type.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IMappingProfile)));

        private void InvokeMapping(Type type) =>
            type.GetMethod("Mapping")?.Invoke(Activator.CreateInstance(type), new object[] { this });
    }
}
