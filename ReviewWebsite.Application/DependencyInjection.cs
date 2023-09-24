using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ReviewWebsite.Application.Authentication.Commands.Register;
using ReviewWebsite.Application.Authentication.Common;
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
            services.AddScoped<
                IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
                ValidateRegisterCommandBehavior>();

            //services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
