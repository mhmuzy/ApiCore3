using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Validações        

namespace Projeto.Presentation.Api.Models.Requests
{
    public class CadastroClienteRequest
    {
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe o endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        public string email { get; set; }

        [StringLength(11, ErrorMessage = "Por favor, informe exatamente {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o cpf do cliente.")]
        public string cpf { get; set; }
    }
}
