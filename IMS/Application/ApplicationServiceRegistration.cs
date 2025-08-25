using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Profiles; // This namespace is added

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // የተሻለው አጻጻፍ: assemblies ን በግልጽ መግለጽ
            // services.AddAutoMapper(typeof(MappingProfile).Assembly);
            // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(SomeHandler).Assembly));

            return services;
        }
    }
}