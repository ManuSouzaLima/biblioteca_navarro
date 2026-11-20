using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

// O que o serviço precisa saber sobre os livros guardados.
// Fica junto do serviço: quem define o contrato é quem precisa dele.
// Repare: nada aqui fala de banco, SQL ou Entity Framework.
public interface ILivroRepository
{
    Task<IEnumerable<Livro>> ListarTodosAsync();
    Task<Livro?> ObterPorIdAsync(int id);

    // "Já existe um livro com este ISBN?" (para não cadastrar duplicado)
    // idIgnorado: no update, o próprio livro não conta como duplicado.
    Task<bool> ExisteIsbnAsync(string isbn, int? idIgnorado);

    // "Este livro tem empréstimos?" (para não apagar livro com histórico)
    Task<bool> PossuiEmprestimosAsync(int id);

    void Adicionar(Livro livro);
    void Remover(Livro livro);

    // Grava de uma vez tudo o que foi adicionado, alterado ou removido
    Task SalvarAlteracoesAsync();
}