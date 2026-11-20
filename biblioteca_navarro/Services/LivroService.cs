using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Implementação do serviço de livros. A lógica será feita quando o repositório for configurado.
public class LivroService : ILivroService
{
    public Task<IEnumerable<Livro>> ListarTodosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Livro?> ObterPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Livro> CriarAsync(Livro livro)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AtualizarAsync(Livro livro)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExcluirAsync(int id)
    {
        throw new NotImplementedException();
    }
}
