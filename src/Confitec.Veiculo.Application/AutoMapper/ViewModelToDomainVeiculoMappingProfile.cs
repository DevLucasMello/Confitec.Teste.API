using AutoMapper;
using Confitec.Veiculo.Application.ViewModels;

namespace Confitec.Veiculo.Application.AutoMapper
{
    public class ViewModelToDomainVeiculoMappingProfile : Profile
    {
        public ViewModelToDomainVeiculoMappingProfile()
        {
            CreateMap<VeiculoViewModel, Domain.Veiculo>()
                .ConstructUsing(v => new Domain.Veiculo(v.CPFCondutor, v.Placa,v.Modelo, v.Marca, v.Cor, v.AnoFabricacao));
        }
    }
}
