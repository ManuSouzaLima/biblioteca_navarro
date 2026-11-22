using biblioteca_navarro.DTOs;
using biblioteca_navarro.Models;
using biblioteca_navarro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_navarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _service;

        public LivroController(ILivroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroDto>>> GetLivros()
        {
            var livros = await _service.ListarTodosAsync();

            return Ok(livros.Select(ParaDto));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroDto>> GetLivro(int id)
        {
            var livro = await _service.ObterPorIdAsync(id);

            if (livro is null)
            {
                return NotFound();
            }

            return Ok(ParaDto(livro));
        }

        [HttpPost]
        public async Task<ActionResult<LivroDto>> PostLivro(CriarLivroDto dto)
        {
            var livro = ParaModel(dto);

            var criado = await _service.CriarAsync(livro);
            return CreatedAtAction(nameof(GetLivro), new { id = criado.Id }, ParaDto(criado));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, CriarLivroDto dto)
        {
            var livro = ParaModel(dto);
            livro.Id = id;

            var atualizado = await _service.AtualizarAsync(livro);

            if (!atualizado)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var excluido = await _service.ExcluirAsync(id);

            if (!excluido)
            {
                return NotFound();
            }

            return NoContent();
        }

        private static LivroDto ParaDto(Livro livro) => new()
        {
            Id = livro.Id,
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            Isbn = livro.Isbn,
            QtdPaginas = livro.QtdPaginas
        };

        private static Livro ParaModel(CriarLivroDto dto) => new()
        {
            Titulo = dto.Titulo,
            Autor = dto.Autor,
            Isbn = dto.Isbn,
            QtdPaginas = dto.QtdPaginas
        };
    }
}
