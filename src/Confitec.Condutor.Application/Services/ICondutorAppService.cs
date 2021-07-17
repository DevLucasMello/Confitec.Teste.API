using Confitec.Condutor.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Condutor.Application.Services
{
    public interface ICondutorAppService : IDisposable
    {
        Task<IEnumerable<CondutorViewModel>> ObterTodosCondutores();        
        Task<CondutorViewModel> ObterCondutorPorId(Guid id);
        Task<CondutorViewModel> ObterCondutorPorCPF(string cpf);
        Task<bool> AdicionarCondutor(CondutorViewModel condutorViewModel);
        Task<bool> AtualizarCondutor(CondutorViewModel condutorViewModel);
        Task<bool> ExcluirCondutor(CondutorViewModel condutorViewModel);
    }
}
