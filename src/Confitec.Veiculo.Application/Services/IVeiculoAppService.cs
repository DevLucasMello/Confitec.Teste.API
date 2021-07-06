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
        Task<VeiculoViewModel> ObterVeiculoPorId(Guid id);
        Task<VeiculoViewModel> ObterVeiculoPorPlaca(string placa);
        Task AdicionarVeiculo(VeiculoViewModel veiculoViewModel);
        Task AtualizarVeiculo(VeiculoViewModel veiculoViewModel);
        Task ExcluirVeiculo(VeiculoViewModel veiculoViewModel);
    }
}
