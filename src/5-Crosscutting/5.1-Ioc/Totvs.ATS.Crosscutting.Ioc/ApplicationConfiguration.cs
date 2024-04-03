using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Totvs.ATS.Domain.Interfaces.Repository;
using Totvs.ATS.Infrastructure.Data;
using Totvs.ATS.Infrastructure.Data.Repository;
using Totvs.ATS.Service;
using Totvs.ATS.Service.Interfaces;
using Totvs.ATS.Shared;
using Totvs.ATS.Shared.Interfaces;

namespace Totvs.ATS.Crosscutting.Ioc
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, IConfiguration config)
        {

            services
                .AddScoped<IBaseNotification, BaseNotification>()
                .AddScoped<IMongoContext, MongoContext>();

            services
                .AddScoped<ICandidateService, CandidateService>()
                .AddScoped<IVacancyService, VacancyService>()
                .AddScoped<ILoginService, LoginService>()
                .AddScoped<ITokenApplication, TokenApplication>()
                .AddScoped<IApplyVacancyCandidateService, ApplyVacancyCandidateService>();
            services
                .AddScoped<ICandidateRepository, CandidateRepository>()
                .AddScoped<IVacancyRepository, VacancyRepository>();

            return services;


        }
    }
}
