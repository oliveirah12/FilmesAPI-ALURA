using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Título obrigatório")]
    [MaxLength(100, ErrorMessage = "Tamanho do Título precisa ser menor que 100 caracteres")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Gênero obrigatório")]
    [MaxLength(50, ErrorMessage = "Tamanho do Gênero precisa ser menor que 50 caracteres")]

    public string Genero { get; set; }

    [Required(ErrorMessage = "Duração obrigatória")]
    [Range(60, 600, ErrorMessage = "Duração deve ter entre 60 e 600 minutos")]
    public int Duracao { get; set; }

}
