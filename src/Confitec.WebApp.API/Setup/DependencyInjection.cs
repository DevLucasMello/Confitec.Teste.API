using Confitec.Cadastro.Application.Services;
using Confitec.Cadastro.Data;
using Confitec.Cadastro.Data.Repository;
using Confitec.Cadastro.Domain;
using Confitec.Condutor.Application.Services;
using Confitec.Condutor.Data;
using Confitec.Condutor.Data.Repository;
using Confitec.Condutor.Domain;
using Confitec.Veiculo.Application.Services;
using Confitec.Veiculo.Data;
using Confitec.Veiculo.Data.Repository;
using Confitec.Veiculo.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.WebApp.API.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Usuario
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<UsuarioContext>();

            // Condutor
            services.AddScoped<ICondutorRepository, CondutorRepository>();
            services.AddScoped<ICondutorAppService, CondutorAppService>();
            services.AddScoped<CondutorContext>();

            // Veiculo
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoAppService, VeiculoAppService>();
            services.AddScoped<VeiculoContext>();

        }
    }
}
