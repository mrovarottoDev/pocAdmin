using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class TbCanalAtendimentoController : ControllerBase
{
    private readonly TbCanalAtendimentoRepository _repo;

    public TbCanalAtendimentoController(TbCanalAtendimentoRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var canal = await _repo.GetByIdAsync(id);
        return canal is not null ? Ok(canal) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TbCanalAtendimentoDto dto)
    {
        var canal = new TbCanalAtendimento
        {
            CodigoCanal = dto.CodigoCanal,
            DescricaoCanal = dto.DescricaoCanal,
            Ativo = dto.Ativo
        };

        await _repo.CreateAsync(canal);
        return CreatedAtAction(nameof(GetById), new { id = dto.CodigoCanal }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TbCanalAtendimentoDto dto)
    {
        var canal = new TbCanalAtendimento
        {
            CodigoCanal = id,
            DescricaoCanal = dto.DescricaoCanal,
            Ativo = dto.Ativo
        };

        await _repo.UpdateAsync(canal);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}