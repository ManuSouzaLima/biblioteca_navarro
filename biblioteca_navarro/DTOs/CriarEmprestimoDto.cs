using System.ComponentModel.DataAnnotations;

namespace biblioteca_navarro.DTOs;
public class CriarEmprestimoDto
{
    [Range(1, int.MaxValue, ErrorMessage = "O UsuarioId deve ser informado.")]
    public int UsuarioId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "O LivroId deve ser informado.")]
    public int LivroId { get; set; }
}
