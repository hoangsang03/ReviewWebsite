using Microsoft.Extensions.DependencyInjection;
using ReviewWebsite.Application.Services.Authentication.Commands;
using ReviewWebsite.Application.Services.Authentication.Queries;

namespace ReviewWebsite.Application
{
    public static class DependencyInjection
    {
        // need install Microsoft.Extensions.DependencyInjection
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            return services;
        }
    }
}
