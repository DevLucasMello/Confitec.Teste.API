using Confitec.Core.DomainObjects;
using FluentValidation;
using System;

namespace Confitec.Veiculo.Domain
{
    public class Veiculo : Entity, IAggregateRoot
    {
        public Guid IdCondutor { get; private set; }
        public string CPFCondutor { get; private set; }
        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        public string Cor { get; private set; }
        public int AnoFabricacao { get; private set; }

        public Veiculo(Guid idCondutor, string cpfCondutor, string placa, string modelo, string marca, string cor, int anoFabricacao)
        {
            IdCondutor = idCondutor;
            CPFCondutor = cpfCondutor;
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            AnoFabricacao = anoFabricacao;
        }

        // EF Rel.
        protected Veiculo() { }        

        public override bool EhValido()
        {
            ValidationResult = new VeiculoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class VeiculoValidation : AbstractValidator<Veiculo>
        {
            public VeiculoValidation()
            {
                RuleFor(v => v.IdCondutor)
                .NotEmpty()
                .WithMessage("O Id do Condutor deve ser informado");

                RuleFor(v => v.CPFCondutor)
                .NotEmpty()
                .WithMessage("O CPF deve ser informado")
                .Must(IsCpfValid)
                .WithMessage("O CPF informado é inválido");

                RuleFor(v => v.Placa)
                .NotEmpty()
                .WithMessage("A Placa deve ser informada")
                .Must(validarPlaca)
                .WithMessage("A Placa informada é inválida");

                RuleFor(v => v.Modelo)
                .NotEmpty()
                .WithMessage("O Modelo deve ser informado");

                RuleFor(s => s.Marca)
                .NotEmpty()
                .WithMessage("O Email não foi informado");                

                RuleFor(c => c.Cor)
                .NotEmpty()
                .WithMessage("A CNH deve ser informada");

                RuleFor(c => c.AnoFabricacao)
                .NotEmpty()
                .WithMessage("A Data de Nascimento deve ser informada");
            }    
        }
    }
}
