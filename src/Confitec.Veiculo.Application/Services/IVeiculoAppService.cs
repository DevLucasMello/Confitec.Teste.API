using Confitec.Veiculo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Veiculo.Application.Services
{
    public interface IVeiculoAppService : IDisposable
    {
        Task<IEnumerable<VeiculoViewModel>> ObterTodosVeiculos();
        Task<IEnumerable<VeiculoViewModel>> ObterVeiculosPorCPF(string cpf);
        Task<IEnumerable<VeiculoViewModel>> ObterVeiculosPorPlaca(string placa);
        Task<VeiculoViewModel> ObterVeiculoPorId(Guid id);        
        Task<bool> AdicionarVeiculo(VeiculoViewModel veiculoViewModel);
        Task<bool> AtualizarVeiculo(VeiculoViewModel veiculoViewModel);
        Task<bool> ExcluirVeiculo(VeiculoViewModel veiculoViewModel);
    }
}
