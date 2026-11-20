using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Implementação do serviço de usuários. A lógica será feita quando o repositório for configurado.
public class UsuarioService : IUsuarioService
{
    public Task<IEnumerable<Usuario>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Usuario?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> CreateAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
