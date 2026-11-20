using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Implementação do serviço de livros. Usa o repositório recebido pelo construtor.
public class LivroService : ILivroService
{
    private readonly ILivroRepository _repositorio;

    public LivroService(ILivroRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IEnumerable<Livro>> ListarTodosAsync()
    {
        return await _repositorio.ListarTodosAsync();
    }

    public async Task<Livro?> ObterPorIdAsync(int id)
    {
        return await _repositorio.ObterPorIdAsync(id);
    }

    public async Task<Livro> CriarAsync(Livro livro)
    {
        _repositorio.Adicionar(livro);
        await _repositorio.SalvarAlteracoesAsync();

        return livro;
    }

    public async Task<bool> AtualizarAsync(Livro livro)
    {
        // Validação: o livro precisa existir (no código de referência, PUT sem registro retorna NotFound)
        var existente = await _repositorio.ObterPorIdAsync(livro.Id);
        if (existente is null)
        {
            return false;
        }

        existente.Titulo = livro.Titulo;
        existente.Autor = livro.Autor;
        existente.Isbn = livro.Isbn;
        existente.QtdPaginas = livro.QtdPaginas;

        await _repositorio.SalvarAlteracoesAsync();
        return true;
    }

    public async Task<bool> ExcluirAsync(int id)
    {
        // Validação: o livro precisa existir (no código de referência, DELETE sem registro retorna NotFound)
        var existente = await _repositorio.ObterPorIdAsync(id);
        if (existente is null)
        {
            return false;
        }

        _repositorio.Remover(existente);
        await _repositorio.SalvarAlteracoesAsync();
        return true;
    }
}
