using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Implementação do serviço de livros. A lógica será feita quando o repositório for configurado.
public class LivroService : ILivroService
{
    public Task<IEnumerable<Livro>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Livro?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Livro> CreateAsync(Livro livro)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Livro livro)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
