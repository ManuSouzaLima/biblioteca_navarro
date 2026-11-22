using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

// O que o serviço precisa saber sobre os empréstimos guardados.
// Fica junto do serviço: quem define o contrato é quem precisa dele.
// Repare: nada aqui fala de banco, SQL ou Entity Framework.
public interface IEmprestimoRepository
{
    Task<IEnumerable<Emprestimo>> ListarTodosAsync();
    Task<Emprestimo?> ObterPorIdAsync(int id);

    void Adicionar(Emprestimo emprestimo);
    void Remover(Emprestimo emprestimo);

    // Grava de uma vez tudo o que foi adicionado, alterado ou removido
    Task SalvarAlteracoesAsync();
}