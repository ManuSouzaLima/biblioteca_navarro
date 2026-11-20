using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Contrato das operações de negócio sobre livros.
public interface ILivroService
{
    Task<IEnumerable<Livro>> ListarTodosAsync();

    Task<Livro?> ObterPorIdAsync(int id);

    Task<Livro> CriarAsync(Livro livro);

    Task<bool> AtualizarAsync(Livro livro);

    Task<bool> ExcluirAsync(int id);
}
