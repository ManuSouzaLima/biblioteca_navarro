using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Implementação do serviço de usuários. A lógica será feita quando o repositório for configurado.
public class UsuarioService : IUsuarioService
{
    public Task<IEnumerable<Usuario>> ListarTodosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Usuario?> ObterPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> CriarAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AtualizarAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExcluirAsync(int id)
    {
        throw new NotImplementedException();
    }
}
