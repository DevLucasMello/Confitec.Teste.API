using AutoMapper;
using Confitec.Veiculo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Veiculo.Application.AutoMapper
{
    class ViewModelToDomainVeiculoMappingProfile : Profile
    {
        public ViewModelToDomainVeiculoMappingProfile()
        {
            CreateMap<VeiculoViewModel, Domain.Veiculo>()
                .ConstructUsing(v => new Domain.Veiculo(v.CPFCondutor, v.Placa,v.Modelo, v.Marca, v.Cor, v.AnoFabricacao));
        }
    }
}
