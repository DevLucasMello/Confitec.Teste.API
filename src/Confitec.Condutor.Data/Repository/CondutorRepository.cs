using Confitec.Condutor.Domain;
using Confitec.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Condutor.Data.Repository
{
    public class CondutorRepository : ICondutorRepository
    {
        private readonly CondutorContext _context;

        public CondutorRepository(CondutorContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Domain.Condutor>> ObterTodos()
        {
            return await _context.Condutores.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Domain.Condutor>> ObterPorPlaca(string placa)
        {
            return await _context.Condutores.AsNoTracking().Where(c => c.Placa == placa).ToListAsync();
        }

        public async Task<Domain.Condutor> ObterPorId(Guid id)
        {
            return await _context.Condutores.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Domain.Condutor> ObterPorCPF(string cpf)
        {
            return await _context.Condutores.AsNoTracking().FirstOrDefaultAsync(c => c.CPF == cpf);
        }        

        public void Adicionar(Domain.Condutor condutor)
        {
            _context.Condutores.Add(condutor);
        }

        public void Atualizar(Domain.Condutor condutor)
        {
            _context.Condutores.Update(condutor);
        }

        public void Excluir(Domain.Condutor condutor)
        {
            _context.Condutores.Remove(condutor);
        }        

        public void Dispose()
        {
            _context.Dispose();
        }        
    }
}
