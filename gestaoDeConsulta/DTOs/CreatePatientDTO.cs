using System.ComponentModel.DataAnnotations;

namespace gestaoDeConsulta.DTOs
{
    public class CreatePatientDTO
    {

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "Permitido no mínimo 3 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^(?:\d{11}|\d{3}\.\d{3}\.\d{3}-\d{2})$", ErrorMessage = "Formato de CPF inválido")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Phone(ErrorMessage = "Formato de telefone inválido")]
        public string Phone { get; set; }
    }
}
