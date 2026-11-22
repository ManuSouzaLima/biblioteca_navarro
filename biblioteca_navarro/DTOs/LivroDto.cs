using System.ComponentModel.DataAnnotations;

namespace biblioteca_navarro.DTOs;
public class LivroDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O título é obrigatório.")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O autor é obrigatório.")]
    public string Autor { get; set; } = string.Empty;

    [Required(ErrorMessage = "O ISBN é obrigatório.")]
    [StringLength(17, MinimumLength = 10, ErrorMessage = "O ISBN deve ter entre 10 e 17 caracteres.")]
    public string Isbn { get; set; } = string.Empty;

    [Range(1, 1000, ErrorMessage = "A quantidade de páginas deve estar entre 1 e 1000.")]
    public int QtdPaginas { get; set; }
}
