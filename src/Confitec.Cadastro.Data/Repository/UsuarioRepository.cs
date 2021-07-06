using Confitec.Cadastro.Domain;
using Confitec.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Cadastro.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public async Task<Usuario> Autenticar(string email, string senha)
        {
            return await _context.Usuarios.AsNoTracking().Where(u => u.Email == email && u.Senha == senha).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
