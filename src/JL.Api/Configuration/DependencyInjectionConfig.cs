using JL.Business.Intefaces.Notificacoes;
using JL.Business.Intefaces.Repository;
using JL.Business.Intefaces.Service;
using JL.Business.Notificacoes;
using JL.Business.Services.Funcionarios;
using JL.Data.Context;
using JL.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace JL.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CadastroFuncionarioContext>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
