﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Nome Obrigatório")]
    public string Nome { get; set; }

    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }
}
