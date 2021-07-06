using AutoMapper;
using Confitec.Cadastro.Application.ViewModels;
using Confitec.Cadastro.Domain;
using System.Threading.Tasks;

namespace Confitec.Cadastro.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task AdicionarUsuario(UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            _usuarioRepository.Adicionar(usuario);

            await _usuarioRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarUsuario(UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            _usuarioRepository.Atualizar(usuario);

            await _usuarioRepository.UnitOfWork.Commit();
        }

        public async Task<UsuarioViewModel> AutenticarUsuario(string email, string senha)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.Autenticar(email, senha));
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}
