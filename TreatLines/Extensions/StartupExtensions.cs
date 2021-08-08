using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.Interfaces;
using TreatLines.BLL.Services;
using TreatLines.Configuration;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Interfaces;
using TreatLines.DAL.Repositories;

namespace TreatLines.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection RegisterDepInj(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<UserRepository>();
            services.AddScoped<IRepository<RequestToCreateHospital>, Repository<RequestToCreateHospital>>();
            services.AddScoped<IRepository<RequestToCreatePatient>, Repository<RequestToCreatePatient>>();
            services.AddScoped<IRepository<Hospital>, Repository<Hospital>>();
            services.AddScoped<IHospitalAdminRepository, HospitalAdminRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorPatientRepository, DoctorPatientRepository>();

            services.AddSingleton<IMailService, MailService>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IHospitalService, HospitalService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddScoped<IHospitalRegistrationRequestsService, HospitalRegistrationRequestsService>();
            services.AddScoped<IPatientRegistrationRequestsService, PatientRegistrationRequestsService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
