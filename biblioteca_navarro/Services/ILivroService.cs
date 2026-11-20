using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Contrato das operações de negócio sobre livros.
public interface ILivroService
{
    Task<IEnumerable<Livro>> GetAllAsync();

    Task<Livro?> GetByIdAsync(int id);

    Task<Livro> CreateAsync(Livro livro);

    Task<bool> UpdateAsync(Livro livro);

    Task<bool> DeleteAsync(int id);
}
