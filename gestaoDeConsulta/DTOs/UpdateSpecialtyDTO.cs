using System.ComponentModel.DataAnnotations;

namespace gestaoDeConsulta.DTOs
{
    public class UpdateSpecialtyDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(80, ErrorMessage = "Só é permitido um nome de no máximo 80 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(150, ErrorMessage = "Só é permitido uma descrição de no máximo 150 caracteres")]
        public string Description { get; set; }
    }
}
