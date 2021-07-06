using AutoMapper;
using Confitec.Condutor.Application.ViewModels;
using Confitec.Motorista.Domain;

namespace Confitec.Condutor.Application.AutoMapper
{
    public class ViewModelToDomainCondutorMappingProfile : Profile
    {
        public ViewModelToDomainCondutorMappingProfile()
        {
            CreateMap<CondutorViewModel, Domain.Condutor>()
                .ConstructUsing(c => new Domain.Condutor(new Nome(c.PrimeiroNome, c.UltimoNome), c.CPF, c.Telefone, c.Email, c.CNH, c.DataNascimento));
        }
    }
}
