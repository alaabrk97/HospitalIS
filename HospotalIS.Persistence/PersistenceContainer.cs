using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using HospitalInfoSystem.Application.Contracts;
using HositalS.Persistence.Repositories;

namespace HositalS.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HospitalISDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("HospitalISConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));

            return services;
        }
    }
}
