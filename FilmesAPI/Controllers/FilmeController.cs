﻿using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;



    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Campos necessários</param>
    /// <returns>IActionResult</returns>
    /// <response code ="201">Caso inserção tenha sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        
        Filme filme = _mapper.Map<Filme>(filmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId),
            new { id = filme.Id}, filme);

    }


    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery]int skip = 0, 
        [FromQuery]int take = 10){
        
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }


    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

        return Ok(filmeDto);
    }


    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody]UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);

        if (filme == null) return NotFound();

        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return NoContent();
    }


    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);

        if (filme == null) return NotFound();

        var filmeParcial = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParcial, ModelState);

        if (!TryValidateModel(filmeParcial))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParcial, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if(filme == null) return NotFound();

        _context.Filmes.Remove(filme);
        _context.SaveChanges();

        return NoContent();
    }

}
