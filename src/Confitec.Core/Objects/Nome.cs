using FluentValidation;
using FluentValidation.Results;
using Confitec.Core.DomainObjects;

namespace Confitec.Motorista.Domain
{
    public class Nome : ValueObject
    {
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }

        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;           
        }

        // EF Rel.
        protected Nome() { }

        public string NomeCompleto()
        {
            return $"{PrimeiroNome} {UltimoNome}";
        }

        public override string ToString()
        {
            return NomeCompleto();
        }

        public override bool EhValido()
        {
            ValidationResult = new NomeValidation().Validate(this);            
            return ValidationResult.IsValid;
        }

        public class NomeValidation : AbstractValidator<Nome>
        {
            public NomeValidation()
            {
                RuleFor(n => n.PrimeiroNome)
                .NotEmpty()
                .WithMessage("O primeiro nome não foi informado")
                .Length(3, 150)
                .WithMessage("O campo nome deve ter entre 3 e 150 caracteres");

                RuleFor(n => n.UltimoNome)
                .NotEmpty()
                .WithMessage("O último nome não foi informado")
                .Length(3, 150)
                .WithMessage("O campo nome deve ter entre 3 e 150 caracteres"); ;
            }
        }
    }
}
