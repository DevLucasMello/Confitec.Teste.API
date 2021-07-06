using Confitec.Core.Data;
using Confitec.Veiculo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Veiculo.Data.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly VeiculoContext _context;

        public VeiculoRepository(VeiculoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Domain.Veiculo>> ObterTodos()
        {
            return await _context.Veiculos.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Domain.Veiculo>> ObterPorCPF(string cpf)
        {
            return await _context.Veiculos.AsNoTracking().Where(v => v.CPFCondutor == cpf).ToListAsync();
        }

        public async Task<Domain.Veiculo> ObterPorId(Guid id)
        {
            return await _context.Veiculos.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Domain.Veiculo> ObterPorPlaca(string placa)
        {
            return await _context.Veiculos.AsNoTracking().FirstOrDefaultAsync(v => v.Placa == placa);
        }

        public void Adicionar(Domain.Veiculo condutor)
        {
            _context.Veiculos.Add(condutor);
        }

        public void Atualizar(Domain.Veiculo condutor)
        {
            _context.Veiculos.Update(condutor);
        }        

        public void Excluir(Domain.Veiculo condutor)
        {
            _context.Veiculos.Remove(condutor);
        }   

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
