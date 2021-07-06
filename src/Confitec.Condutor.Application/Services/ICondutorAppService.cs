using Confitec.Condutor.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Condutor.Application.Services
{
    public interface ICondutorAppService : IDisposable
    {
        Task<IEnumerable<CondutorViewModel>> ObterTodosCondutores();
        Task<IEnumerable<CondutorViewModel>> ObterCondutoresPorPlaca(string placa);
        Task<CondutorViewModel> ObterCondutorPorId(Guid id);
        Task<CondutorViewModel> ObterCondutorPorCPF(string cpf);
        Task AdicionarCondutor(CondutorViewModel condutorViewModel);
        Task AtualizarCondutor(CondutorViewModel condutorViewModel);
        Task ExcluirCondutor(CondutorViewModel condutorViewModel);
    }
}
