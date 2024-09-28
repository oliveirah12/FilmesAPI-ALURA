using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;


public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Logradouro Obrigatório")]
    [MaxLength(255, ErrorMessage = "O Logradouro não pode ter mais que 255 caracteres")]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "Número Obrigatório")]
    public int Numero { get; set; }
    public virtual Cinema Cinema { get; set; }


}
