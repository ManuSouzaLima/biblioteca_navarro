namespace biblioteca_navarro.DTOs;
public class EmprestimoDto
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }
    public string NomeUsuario { get; set; } = string.Empty;

    public int LivroId { get; set; }
    public string TituloLivro { get; set; } = string.Empty;

    public DateTime DataEmprestimo { get; set; }
}
