using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Confitec.Condutor.Application.ViewModels
{
    public class CondutorViewModel
    {
        //[Key]
        //public Guid Id { get; set; }           

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        //[MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        //public string PrimeiroNome { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        //[MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        //public string UltimoNome { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[MaxLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        //[MinLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        //public string CPF { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[MaxLength(11, ErrorMessage = "Este campo deve conter entre 8 e 11 caracteres")]
        //[MinLength(8, ErrorMessage = "Este campo deve conter entre 8 e 11 caracteres")]
        //public string Telefone { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[MaxLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        //[MinLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        //public string CNH { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[DataType(DataType.DateTime, ErrorMessage = "Data Inválida")]
        //[Range(typeof(DateTime), "01/01/1753", "31/12/9999")]
        //public DateTime DataNascimento { get; set; }

        [Key]        
        public Guid Id { get; set; } 
       
        public string PrimeiroNome { get; set; }
        
        public string UltimoNome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        [MinLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        public string CPF { get; set; }

        public string Telefone { get; set; }
       
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        [MinLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        public string CNH { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
