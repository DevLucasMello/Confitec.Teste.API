using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Confitec.Veiculo.Application.ViewModels
{
    public class VeiculoViewModel
    {
        [Key]
        public Guid Id { get; set; }        
        public Guid IdCondutor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        [MinLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        public string CPFCondutor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(8, ErrorMessage = "Este campo deve conter entre 7 e 8 caracteres")]
        [MinLength(7, ErrorMessage = "Este campo deve conter entre 7 e 8 caracteres")]
        public string Placa { get; set; }        
        public string Modelo { get; set; }        
        public string Marca { get; set; }        
        public string Cor { get; set; }        
        public int AnoFabricacao { get; set; }
    }
}
