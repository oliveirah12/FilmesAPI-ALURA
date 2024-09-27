using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{

    private IMapper _mapper;
    private FilmeContext _context;

    public EnderecoController(IMapper mapper, FilmeContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    [HttpPost]
    public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, enderecoDto);
    }


    [HttpGet]
    public IEnumerable<ReadEnderecoDto> RecuperaEnderecos()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
    }


    [HttpGet("{id}")]
    public IActionResult RecuperaEnderecoPorId(int id) { 
        
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

        if (endereco == null) return NotFound();

        var enderecoDto = _mapper.Map<ReadCinemaDto>(endereco);
        return Ok(endereco);
    }

    [HttpPut]
    public IActionResult AtualizaEndereco(int id, [FromBody] UpdateCinemaDto enderecoDto)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();

        return NoContent();

    } 

    [HttpDelete("{id}")]
    public IActionResult DeletaEndereco(int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco =>endereco.Id == id);
        if (endereco == null) return NotFound();

        _context.Remove(endereco);
        _context.SaveChanges();

        return NoContent();
    }


}
