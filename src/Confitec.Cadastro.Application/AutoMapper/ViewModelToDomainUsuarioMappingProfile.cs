using AutoMapper;
using Confitec.Cadastro.Application.ViewModels;
using Confitec.Cadastro.Domain;
using Confitec.Motorista.Domain;

namespace Confitec.Cadastro.Application.AutoMapper
{
    public class ViewModelToDomainUsuarioMappingProfile : Profile
    {
        public ViewModelToDomainUsuarioMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>()
                .ConstructUsing(u => new Usuario(new Nome(u.PrimeiroNome, u.UltimoNome), u.Email, u.Senha));
        }
    }
}
