using Confitec.Cadastro.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace Confitec.Cadastro.Application.Services
{
    public interface IUsuarioAppService : IDisposable
    {
        Task AdicionarUsuario(UsuarioViewModel usuarioViewModel);
        Task AtualizarUsuario(UsuarioViewModel usuarioViewModel);
        Task<UsuarioViewModel> AutenticarUsuario(string email, string senha);
    }
}
