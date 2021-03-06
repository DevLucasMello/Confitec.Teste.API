using Confitec.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Veiculo.Domain
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<IEnumerable<Veiculo>> ObterTodos();
        Task<IEnumerable<Veiculo>> ObterPorCPF(string cpf);
        Task<IEnumerable<Veiculo>> ObterPorPlaca(string placa);
        Task<Veiculo> ObterPorId(Guid id);        
        void Adicionar(Veiculo condutor);
        void Atualizar(Veiculo condutor);
        void Excluir(Veiculo condutor);
    }
}
