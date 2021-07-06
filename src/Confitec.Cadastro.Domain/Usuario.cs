using Confitec.Core.DomainObjects;
using Confitec.Motorista.Domain;
using FluentValidation;

namespace Confitec.Cadastro.Domain
{
    public class Usuario : Entity, IAggregateRoot
    {
        public Nome Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public Usuario(Nome nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        // EF Rel.
        protected Usuario() { }

        public override bool EhValido()
        {
            ValidationResult = new UsuarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UsuarioValidation : AbstractValidator<Usuario>
        {
            public UsuarioValidation()
            {
                RuleFor(s => s.Email)
                .NotEmpty()
                .WithMessage("O Email não foi informado")
                .EmailAddress()
                .WithMessage("Endereço de E-mail inválido");

                RuleFor(n => n.Senha)
                .NotEmpty()                
                .WithMessage("A senha não foi informada");
            }
        }
    }
}
