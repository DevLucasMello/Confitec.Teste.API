using Confitec.Core.Data;
using System.Threading.Tasks;

namespace Confitec.Cadastro.Domain
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {        
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        Task<Usuario> Autenticar(string email, string senha);
    }
}
