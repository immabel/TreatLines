﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.Interfaces;
using TreatLines.BLL.JwtAuthentication;
using TreatLines.BLL.Services;
using TreatLines.Configuration;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Interfaces;
using TreatLines.DAL.Repositories;

namespace TreatLines.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddJwtTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenProvider = new JwtAuthenticationManager(configuration);
            services
                .AddSingleton<IJwtAuthenticationManager>(tokenProvider)
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    authenticationScheme: JwtBearerDefaults.AuthenticationScheme,
                    configureOptions: options =>
                    {
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = tokenProvider.TokenValidationParameters;
                    });
            return services;
        }

        public static IServiceCollection RegisterDepInj(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<UserRepository>();
            services.AddScoped<IRepository<RequestToCreateHospital>, Repository<RequestToCreateHospital>>();
            services.AddScoped<IRepository<Hospital>, Repository<Hospital>>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddSingleton<IMailService, MailService>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<IHospitalRegistrationRequestsService, HospitalRegistrationRequestsService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}