using biblioteca_navarro.Models;
using biblioteca_navarro.Services;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_navarro.Data;

// Implementação do contrato usando Entity Framework Core.
// É o único lugar, fora do AppDbContext, que conhece o EF.
public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    // O AppDbContext chega pelo construtor (injeção de dependência)
    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> ListarTodosAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario?> ObterPorIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<bool> ExisteRaAsync(string ra, int? idIgnorado)
    {
        return await _context.Usuarios.AnyAsync(u =>
            u.Ra == ra &&
            (idIgnorado == null || u.Id != idIgnorado));
    }

    public async Task<bool> PossuiEmprestimosAsync(int id)
    {
        return await _context.Emprestimos.AnyAsync(e => e.UsuarioId == id);
    }

    public void Adicionar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
    }

    public void Remover(Usuario usuario)
    {
        _context.Usuarios.Remove(usuario);
    }

    public async Task SalvarAlteracoesAsync()
    {
        await _context.SaveChangesAsync();
    }
}