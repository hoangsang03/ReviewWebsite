﻿using Microsoft.Extensions.DependencyInjection;
using ReviewWebsite.Application.Services.Authentication;
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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
