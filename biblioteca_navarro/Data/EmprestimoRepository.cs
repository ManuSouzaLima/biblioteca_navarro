using biblioteca_navarro.Models;
using biblioteca_navarro.Services;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_navarro.Data;

// Implementação do contrato usando Entity Framework Core.
// É o único lugar, fora do AppDbContext, que conhece o EF.
public class EmprestimoRepository : IEmprestimoRepository
{
    private readonly AppDbContext _context;

    // O AppDbContext chega pelo construtor (injeção de dependência)
    public EmprestimoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Emprestimo>> ListarTodosAsync()
    {
        return await _context.Emprestimos
            .Include(e => e.Usuario)
            .Include(e => e.Livro)
            .ToListAsync();
    }

    public async Task<Emprestimo?> ObterPorIdAsync(int id)
    {
        return await _context.Emprestimos
            .Include(e => e.Usuario)
            .Include(e => e.Livro)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public void Adicionar(Emprestimo emprestimo)
    {
        _context.Emprestimos.Add(emprestimo);
    }

    public void Remover(Emprestimo emprestimo)
    {
        _context.Emprestimos.Remove(emprestimo);
    }

    public async Task SalvarAlteracoesAsync()
    {
        await _context.SaveChangesAsync();
    }
}