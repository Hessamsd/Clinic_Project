using ClinicManagement.Application;
using ClinicManagement.Application.Contracts.Doctor;
using ClinicManagement.Domain.DoctorAgg;
using ClinicManagement.Infrastructure.EFCore.Repository;
using Framework.Domain;
using Framework.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManagement.Infrastructure.Configuration
{
    public class ClinicManagementBootstrapper
    {

        public static void Configure(IServiceCollection services)
        {


            services.AddScoped<IDoctorApplication, DoctorApplication>();
                       
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            services.AddScoped(typeof(IRepository<,>), typeof(RepositoryBase<,>));
                        
        }

    }
}
