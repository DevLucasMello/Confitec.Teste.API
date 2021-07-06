using AutoMapper;
using Confitec.Veiculo.Application.ViewModels;

namespace Confitec.Veiculo.Application.AutoMapper
{
    class DomainVeiculoToViewModelMappingProfile : Profile
    {
        public DomainVeiculoToViewModelMappingProfile()
        {
            CreateMap<Domain.Veiculo, VeiculoViewModel>();
        }
    }
}
