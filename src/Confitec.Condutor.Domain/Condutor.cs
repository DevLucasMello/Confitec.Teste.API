using Confitec.Core.DomainObjects;
using Confitec.Motorista.Domain;
using FluentValidation;
using System;

namespace Confitec.Condutor.Domain
{
    public class Condutor : Entity, IAggregateRoot
    {        
        public Nome Nome { get; private set; }
        public string CPF { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string CNH { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Condutor(Nome nome, string cpf, string telefone, string email, string cnh, DateTime dataNascimento)
        {            
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Email = email;
            CNH = cnh;
            DataNascimento = dataNascimento;
        }

        // EF Rel.
        protected Condutor() { }

        public override bool EhValido()
        {
            ValidationResult = new CondutorValidation().Validate(this);            
            return ValidationResult.IsValid;
        }

        public class CondutorValidation : AbstractValidator<Condutor>
        {
            public CondutorValidation()
            {
                RuleFor(c => c.CPF)
                .NotEmpty()
                .WithMessage("O CPF deve ser informado")
                .Must(IsCpfValid)
                .WithMessage("O CPF informado é inválido"); ;

                RuleFor(c => c.Telefone)
                .NotEmpty()
                .WithMessage("O Telefone deve ser preenchido")
                .MinimumLength(9)
                .WithMessage("Informe o telefone com no mínimo 9 digitos");

                RuleFor(s => s.Email)
                .NotEmpty()
                .WithMessage("O Email não foi informado")
                .EmailAddress()
                .WithMessage("Endereço de E-mail inválido");

                RuleFor(c => c.CNH)
                .NotEmpty()
                .WithMessage("A CNH deve ser informada");

                RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .WithMessage("A Data de Nascimento deve ser informada")
                .Must(CondutorMaiorDeIdade)
                .WithMessage("O Condutor deve ter no mínimo 18 anos");
            }

            private static bool CondutorMaiorDeIdade(DateTime dataNascimento)
            {
                return dataNascimento <= DateTime.Now.AddYears(-18);
            }
        }
    }
}
