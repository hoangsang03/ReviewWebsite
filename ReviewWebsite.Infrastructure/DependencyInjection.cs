using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReviewWebsite.Application.Common.Interfaces.Authentication;
using ReviewWebsite.Application.Common.Interfaces.Persistence;
using ReviewWebsite.Application.Common.Interfaces.Services;
using ReviewWebsite.Infrastructure.Authentication;
using ReviewWebsite.Infrastructure.Persistence;
using ReviewWebsite.Infrastructure.Persistence.Repositories;
using ReviewWebsite.Infrastructure.Services;
using System.Text;

namespace ReviewWebsite.Infrastructure
{
    public static class DependencyInjection
    {
        // need install Microsoft.Extensions.DependencyInjection
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddAuth(configuration)
                    .AddPersistance();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }

        public static void AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<ReviewWebsiteContext>(
                options => options.UseSqlServer());
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var jwtSetting = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSetting);
            services.AddSingleton(Options.Create(jwtSetting));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters
                = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSetting.Issuer,
                    ValidAudience = jwtSetting.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSetting.Secret))
                });
            return services;
        }
    }
}
