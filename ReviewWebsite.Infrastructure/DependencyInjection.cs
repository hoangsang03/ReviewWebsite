using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReviewWebsite.Application.Common.Interfaces.Authentication;
using ReviewWebsite.Application.Common.Interfaces.Services;
using ReviewWebsite.Application.Services.Persistence;
using ReviewWebsite.Infrastructure.Authentication;
using ReviewWebsite.Infrastructure.Persistence;
using ReviewWebsite.Infrastructure.Services;

namespace ReviewWebsite.Infrastructure
{
    public static class DependencyInjection
    {
        // need install Microsoft.Extensions.DependencyInjection
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
