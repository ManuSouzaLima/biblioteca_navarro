namespace biblioteca_navarro.Models;

// Representa o empréstimo de um livro para um usuário.
// É a ponte entre Livro e Usuario (duas relações 1:N).
public class Emprestimo
{
    public int Id { get; set; }

    // Chave estrangeira para o usuário que pegou o livro.
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }

    // Chave estrangeira para o livro emprestado.
    public int LivroId { get; set; }
    public Livro? Livro { get; set; }

    // Preenchida automaticamente com a data e hora do empréstimo.
    public DateTime DataEmprestimo { get; set; } = DateTime.Now;
}