using Confitec.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Condutor.Domain
{
    public interface ICondutorRepository : IRepository<Condutor>
    {
        Task<IEnumerable<Condutor>> ObterTodos();        
        Task<Condutor> ObterPorId(Guid id);
        Task<Condutor> ObterPorCPF(string cpf);              
        void Adicionar(Condutor condutor);
        void Atualizar(Condutor condutor);
        void Excluir(Condutor condutor);
    }
}
