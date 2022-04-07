using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
namespace HospitalInfoSystem.Application
{
    public static class ApplicationContainer
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;    
        }
    }
}
