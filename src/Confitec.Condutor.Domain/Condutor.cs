using Confitec.Core.DomainObjects;
using Confitec.Motorista.Domain;
using FluentValidation;
using System;

namespace Confitec.Condutor.Domain
{
    public class Condutor : Entity, IAggregateRoot
    {
        public string Placa { get; private set; }
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

        public void AdicionarVeiculo(string placa)
        {
            if (string.IsNullOrEmpty(placa)) throw new DomainException("Veículo não cadastrado");
            Placa = placa;
        }

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

            private static bool IsCpfValid(string cpf)
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                cpf = cpf.Trim().Replace(".", "").Replace("-", "");
                if (cpf.Length != 11)
                    return false;

                for (int j = 0; j < 10; j++)
                    if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                        return false;

                string tempCpf = cpf.Substring(0, 9);
                int soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                int resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                string digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cpf.EndsWith(digito);
            }            
        }
    }
}
