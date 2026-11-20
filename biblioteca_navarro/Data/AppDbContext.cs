using biblioteca_navarro.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace biblioteca_navarro.Data;

// A "porta" da API para o banco de dados.
public class AppDbContext : DbContext
{
    // As opções (qual banco usar e onde ele está) vêm do Program.cs
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Cada DbSet vira uma tabela no banco.
    public DbSet<Livro> Livros => Set<Livro>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Emprestimo> Emprestimos => Set<Emprestimo>();

    // Configuração dos relacionamentos (Fluent API).
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1 Usuario -> N Emprestimos
        modelBuilder.Entity<Emprestimo>()
            .HasOne(e => e.Usuario)              // um empréstimo tem um usuário
            .WithMany()                           // um usuário tem vários empréstimos
            .HasForeignKey(e => e.UsuarioId)      // a FK é o UsuarioId
            .OnDelete(DeleteBehavior.Restrict);   // não deixa apagar usuário com empréstimo

        // 1 Livro -> N Emprestimos
        modelBuilder.Entity<Emprestimo>()
            .HasOne(e => e.Livro)                 // um empréstimo tem um livro
            .WithMany(l => l.Emprestimos)         // um livro tem vários empréstimos
            .HasForeignKey(e => e.LivroId)        // a FK é o LivroId
            .OnDelete(DeleteBehavior.Restrict);   // não deixa apagar livro com empréstimo
    }
}