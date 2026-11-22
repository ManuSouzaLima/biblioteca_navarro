using biblioteca_navarro.DTOs;
using biblioteca_navarro.Models;
using biblioteca_navarro.Services;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_navarro.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmprestimosController : ControllerBase
{
    private readonly IEmprestimoService _emprestimoService;

    public EmprestimosController(IEmprestimoService emprestimoService)
    {
        _emprestimoService = emprestimoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmprestimoDto>>> GetEmprestimos()
    {
        var emprestimos = await _emprestimoService.ListarTodosAsync();

        return Ok(emprestimos.Select(ParaDto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmprestimoDto>> GetEmprestimo(int id)
    {
        var emprestimo = await _emprestimoService.ObterPorIdAsync(id);

        if (emprestimo is null)
        {
            return NotFound();
        }

        return Ok(ParaDto(emprestimo));
    }

    [HttpPost]
    public async Task<ActionResult<EmprestimoDto>> PostEmprestimo(CriarEmprestimoDto dto)
    {
        var erro = await _emprestimoService.ValidarReferenciasAsync(dto.UsuarioId, dto.LivroId);

        if (erro is not null)
        {
            return BadRequest(erro);
        }

        var emprestimo = new Emprestimo
        {
            UsuarioId = dto.UsuarioId,
            LivroId = dto.LivroId
        };

        var criado = await _emprestimoService.CriarAsync(emprestimo);

        // Busca de novo para carregar Usuario e Livro (necessários para os nomes no DTO).
        var completo = await _emprestimoService.ObterPorIdAsync(criado.Id) ?? criado;

        return CreatedAtAction(nameof(GetEmprestimo), new { id = criado.Id }, ParaDto(completo));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmprestimo(int id, CriarEmprestimoDto dto)
    {
        var erro = await _emprestimoService.ValidarReferenciasAsync(dto.UsuarioId, dto.LivroId);

        if (erro is not null)
        {
            return BadRequest(erro);
        }

        var emprestimo = new Emprestimo
        {
            Id = id,
            UsuarioId = dto.UsuarioId,
            LivroId = dto.LivroId
        };

        var atualizado = await _emprestimoService.AtualizarAsync(emprestimo);

        if (!atualizado)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmprestimo(int id)
    {
        var excluido = await _emprestimoService.ExcluirAsync(id);

        if (!excluido)
        {
            return NotFound();
        }

        return NoContent();
    }

    private static EmprestimoDto ParaDto(Emprestimo emprestimo) => new()
    {
        Id = emprestimo.Id,
        UsuarioId = emprestimo.UsuarioId,
        NomeUsuario = emprestimo.Usuario?.Nome ?? string.Empty,
        LivroId = emprestimo.LivroId,
        TituloLivro = emprestimo.Livro?.Titulo ?? string.Empty,
        DataEmprestimo = emprestimo.DataEmprestimo
    };
}
