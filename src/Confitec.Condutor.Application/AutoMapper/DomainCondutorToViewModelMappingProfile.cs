using AutoMapper;
using Confitec.Condutor.Application.ViewModels;

namespace Confitec.Condutor.Application.AutoMapper
{
    public class DomainCondutorToViewModelMappingProfile : Profile
    {
        public DomainCondutorToViewModelMappingProfile()
        {
            CreateMap<Domain.Condutor, CondutorViewModel>()
                .ForMember(n => n.PrimeiroNome, c => c.MapFrom(c => c.Nome.PrimeiroNome))
                .ForMember(n => n.UltimoNome, c => c.MapFrom(c => c.Nome.UltimoNome));
        }
    }
}
