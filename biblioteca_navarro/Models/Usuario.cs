using System.ComponentModel.DataAnnotations;

namespace biblioteca_navarro.Models;

/// Representa um usuário (aluno) cadastrado na biblioteca.
public class Usuario
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O RA é obrigatório.")]
    [StringLength(20, ErrorMessage = "O RA deve ter no máximo 20 caracteres.")]
    public string Ra { get; set; } = string.Empty;

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
    [StringLength(254, ErrorMessage = "O e-mail deve ter no máximo 254 caracteres.")]
    public string Email { get; set; } = string.Empty;
}
