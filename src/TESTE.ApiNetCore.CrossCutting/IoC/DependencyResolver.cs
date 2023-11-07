using Microsoft.Extensions.DependencyInjection;
using TESTE.ApiNetCore.Application;
using TESTE.ApiNetCore.Application.Interfaces;
using TESTE.ApiNetCore.Domain.Repositories;
using TESTE.ApiNetCore.Infrastructure.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace TESTE.ApiNetCore.CrossCutting.IoC
{
    [ExcludeFromCodeCoverage]
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterRepositories(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<IClienteApplication, ClienteApplication>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}