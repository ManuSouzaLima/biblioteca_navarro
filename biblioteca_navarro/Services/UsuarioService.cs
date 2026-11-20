using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Implementação do serviço de usuários. Usa o repositório recebido pelo construtor.
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repositorio;

    public UsuarioService(IUsuarioRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IEnumerable<Usuario>> ListarTodosAsync()
    {
        return await _repositorio.ListarTodosAsync();
    }

    public async Task<Usuario?> ObterPorIdAsync(int id)
    {
        return await _repositorio.ObterPorIdAsync(id);
    }

    public async Task<Usuario> CriarAsync(Usuario usuario)
    {
        _repositorio.Adicionar(usuario);
        await _repositorio.SalvarAlteracoesAsync();

        return usuario;
    }

    public async Task<bool> AtualizarAsync(Usuario usuario)
    {
        // Validação: o usuário precisa existir (no código de referência, PUT sem registro retorna NotFound)
        var existente = await _repositorio.ObterPorIdAsync(usuario.Id);
        if (existente is null)
        {
            return false;
        }

        existente.Nome = usuario.Nome;
        existente.Ra = usuario.Ra;
        existente.Telefone = usuario.Telefone;
        existente.Email = usuario.Email;

        await _repositorio.SalvarAlteracoesAsync();
        return true;
    }

    public async Task<bool> ExcluirAsync(int id)
    {
        // Validação: o usuário precisa existir (no código de referência, DELETE sem registro retorna NotFound)
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
