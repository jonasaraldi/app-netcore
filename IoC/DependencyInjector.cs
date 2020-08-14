using Application.Providers.Users;
using Application.Services.TokenServices;
using Application.Updaters.Users;
using CrossCutting.Helpers.Crypto.Strategies.Md5;
using Data.Repositories.Users;
using Data.UnityOfWorks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IoC
{
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            RegisterProviders(services);
            RegisterRepositories(services);
            RegisterServices(services);
            RegisterStrategies(services);
            RegisterUnitsOfWork(services);
            RegisterUpdaters(services);
        }

        private static void RegisterProviders(IServiceCollection services)
        {
            services.AddScoped<IUserProvider, UserProvider>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ITokenService, TokenService>();
        }

        private static void RegisterStrategies(IServiceCollection services)
        {
            services.AddScoped<IMd5CryptoStrategy, Md5CryptoStrategy>();
        }

        private static void RegisterUnitsOfWork(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        private static void RegisterUpdaters(IServiceCollection services)
        {
            services.AddScoped<IUserUpdater, UserUpdater>();
        }
    }
}