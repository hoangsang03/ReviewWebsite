using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ReviewWebsite.Application.Common.Behaviors;
using System.Reflection;

namespace ReviewWebsite.Application
{
    public static class DependencyInjection
    {
        // need install Microsoft.Extensions.DependencyInjection
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            #region validator
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion
            return services;
        }
    }
}
