using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Contrato das operações de negócio sobre usuários.
public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> ListarTodosAsync();

    Task<Usuario?> ObterPorIdAsync(int id);

    Task<Usuario> CriarAsync(Usuario usuario);

    Task<bool> AtualizarAsync(Usuario usuario);

    Task<bool> ExcluirAsync(int id);
}
