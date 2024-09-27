using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class CreateEnderecoDto
{

    [Required(ErrorMessage = "Logradouro Obrigatório")]
    [MaxLength(255, ErrorMessage = "O Logradouro não pode ter mais que 255 caracteres")]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "Número Obrigatório")]
    public int Numero { get; set; }


}
