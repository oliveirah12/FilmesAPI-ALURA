using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;


public class CreateCinemaDto
{

    [Required(ErrorMessage = "Nome Obrigatório")]
    public string Nome { get; set; }


}
