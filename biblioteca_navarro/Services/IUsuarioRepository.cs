using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

// O que o serviço precisa saber sobre os usuários guardados.
// Fica junto do serviço: quem define o contrato é quem precisa dele.
// Repare: nada aqui fala de banco, SQL ou Entity Framework.
public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> ListarTodosAsync();
    Task<Usuario?> ObterPorIdAsync(int id);

    // "Já existe um usuário com este RA?" (para não cadastrar duplicado)
    // idIgnorado: no update, o próprio usuário não conta como duplicado.
    Task<bool> ExisteRaAsync(string ra, int? idIgnorado);

    // "Este usuário tem empréstimos?" (para não apagar usuário com histórico)
    Task<bool> PossuiEmprestimosAsync(int id);

    void Adicionar(Usuario usuario);
    void Remover(Usuario usuario);

    // Grava de uma vez tudo o que foi adicionado, alterado ou removido
    Task SalvarAlteracoesAsync();
}