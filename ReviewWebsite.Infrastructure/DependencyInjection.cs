using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReviewWebsite.Application.Common.Interfaces.Authentication;
using ReviewWebsite.Application.Common.Interfaces.Services;
using ReviewWebsite.Application.Services.Authentication;
using ReviewWebsite.Infrastructure.Authentication;
using ReviewWebsite.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewWebsite.Infrastructure
{
    public static class DependencyInjection
    {
        // need install Microsoft.Extensions.DependencyInjection
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator> ();
            services.AddSingleton<IDateTimeProvider,DateTimeProvider> ();
            return services;
        }
    }
}
