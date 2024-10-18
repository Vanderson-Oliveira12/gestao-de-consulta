using System.ComponentModel.DataAnnotations;

namespace gestaoDeConsulta.DTOs
{
    public class UpdatePatientDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "Permitido no mínimo 3 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Phone(ErrorMessage = "Formato de telefone inválido")]
        public string Phone { get; set; }
    }
}
