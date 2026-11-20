using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Contrato das operações de negócio sobre usuários.
public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> GetAllAsync();

    Task<Usuario?> GetByIdAsync(int id);

    Task<Usuario> CreateAsync(Usuario usuario);

    Task<bool> UpdateAsync(Usuario usuario);

    Task<bool> DeleteAsync(int id);
}
