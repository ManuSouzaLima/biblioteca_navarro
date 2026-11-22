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
    public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimos()
    {
        return Ok(await _emprestimoService.ListarTodosAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Emprestimo>> GetEmprestimo(int id)
    {
        var emprestimo = await _emprestimoService.ObterPorIdAsync(id);

        if (emprestimo is null)
        {
            return NotFound();
        }

        return Ok(emprestimo);
    }

    [HttpPost]
    public async Task<ActionResult<Emprestimo>> PostEmprestimo(Emprestimo emprestimo)
    {
        var criado = await _emprestimoService.CriarAsync(emprestimo);

        return CreatedAtAction(nameof(GetEmprestimo), new { id = criado.Id }, criado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmprestimo(int id, Emprestimo emprestimo)
    {
        if (id != emprestimo.Id)
        {
            return BadRequest();
        }

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
}