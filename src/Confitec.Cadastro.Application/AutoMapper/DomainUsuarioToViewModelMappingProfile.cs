using AutoMapper;
using Confitec.Cadastro.Application.ViewModels;
using Confitec.Cadastro.Domain;

namespace Confitec.Cadastro.Application.AutoMapper
{
    public class DomainUsuarioToViewModelMappingProfile : Profile
    {
        public DomainUsuarioToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(n => n.PrimeiroNome, u => u.MapFrom(u => u.Nome.PrimeiroNome))
                .ForMember(n => n.UltimoNome, u => u.MapFrom(u => u.Nome.UltimoNome));
        }
    }
}
