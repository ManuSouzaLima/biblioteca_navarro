using biblioteca_navarro.DTOs;
using biblioteca_navarro.Models;
using biblioteca_navarro.Services;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_navarro.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuario()
    {
        var usuarios = await _usuarioService.ListarTodosAsync();

        return Ok(usuarios.Select(ParaDto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDto>> GetUsuario(int id)
    {
        var usuario = await _usuarioService.ObterPorIdAsync(id);

        if (usuario is null)
        {
            return NotFound();
        }

        return ParaDto(usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
    {
        if (id != usuario.Id)
        {
            return BadRequest();
        }

        var atualizado = await _usuarioService.AtualizarAsync(usuario);

        if (!atualizado)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioDto>> PostUsuario(Usuario usuario)
    {
        var criado = await _usuarioService.CriarAsync(usuario);

        return CreatedAtAction("GetUsuario", new { id = criado.Id }, ParaDto(criado));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var excluido = await _usuarioService.ExcluirAsync(id);

        if (!excluido)
        {
            return NotFound();
        }

        return NoContent();
    }

    private static UsuarioDto ParaDto(Usuario usuario) => new()
    {
        Id = usuario.Id,
        Nome = usuario.Nome,
        Ra = usuario.Ra,
        Telefone = usuario.Telefone,
        Email = usuario.Email
    };
}
