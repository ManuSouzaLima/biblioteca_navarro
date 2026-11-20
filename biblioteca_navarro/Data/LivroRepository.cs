using biblioteca_navarro.Models;
using biblioteca_navarro.Services;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_navarro.Data;

// Implementação do contrato usando Entity Framework Core.
// É o único lugar, fora do AppDbContext, que conhece o EF.
public class LivroRepository : ILivroRepository
{
    private readonly AppDbContext _context;

    // O AppDbContext chega pelo construtor (injeção de dependência)
    public LivroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Livro>> ListarTodosAsync()
    {
        return await _context.Livros.ToListAsync();
    }

    public async Task<Livro?> ObterPorIdAsync(int id)
    {
        return await _context.Livros.FindAsync(id);
    }

    public async Task<bool> ExisteIsbnAsync(string isbn, int? idIgnorado)
    {
        return await _context.Livros.AnyAsync(l =>
            l.Isbn == isbn &&
            (idIgnorado == null || l.Id != idIgnorado));
    }

    public async Task<bool> PossuiEmprestimosAsync(int id)
    {
        return await _context.Emprestimos.AnyAsync(e => e.LivroId == id);
    }

    public void Adicionar(Livro livro)
    {
        _context.Livros.Add(livro);
    }

    public void Remover(Livro livro)
    {
        _context.Livros.Remove(livro);
    }

    public async Task SalvarAlteracoesAsync()
    {
        await _context.SaveChangesAsync();
    }
}