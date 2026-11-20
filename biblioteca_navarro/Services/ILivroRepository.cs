using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

// O que o serviço precisa saber sobre os livros guardados.
// Fica junto do serviço: quem define o contrato é quem precisa dele.
// Repare: nada aqui fala de banco, SQL ou Entity Framework.
public interface ILivroRepository
{
    Task<IEnumerable<Livro>> GetAllAsync();
    Task<Livro?> GetByIdAsync(int id);

    // "Já existe um livro com este ISBN?" (para não cadastrar duplicado)
    // idIgnorado: no update, o próprio livro não conta como duplicado.
    Task<bool> ExistsByIsbnAsync(string isbn, int? idIgnorado);

    // "Este livro tem empréstimos?" (para não apagar livro com histórico)
    Task<bool> HasEmprestimosAsync(int id);

    void Add(Livro livro);
    void Remove(Livro livro);

    // Grava de uma vez tudo o que foi adicionado, alterado ou removido
    Task SaveChangesAsync();
}