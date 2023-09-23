using Microsoft.AspNetCore.Mvc.Infrastructure;
using ReviewWebsite.Api.Common.Errors;
using ReviewWebsite.Api.Common.Mapping;

namespace ReviewWebsite.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, ReviewWebsiteProblemDetailFactory>();
            services.AddMappings();
            return services;
        }
    }
}
