﻿using Core.Security.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ITokenHelper, JwtHelper>();
            return services;
        }
    }
}
