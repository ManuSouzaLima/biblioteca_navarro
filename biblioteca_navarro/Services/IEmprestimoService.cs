using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Contrato das operações de negócio sobre empréstimos.
public interface IEmprestimoService
{
    Task<IEnumerable<Emprestimo>> ListarTodosAsync();

    Task<Emprestimo?> ObterPorIdAsync(int id);

    Task<Emprestimo> CriarAsync(Emprestimo emprestimo);

    Task<bool> AtualizarAsync(Emprestimo emprestimo);

    Task<bool> ExcluirAsync(int id);

    // Retorna uma mensagem de erro se o usuário ou o livro não existir; null se estiver tudo certo.
    Task<string?> ValidarReferenciasAsync(int usuarioId, int livroId);
}