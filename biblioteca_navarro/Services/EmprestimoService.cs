using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Implementação do serviço de empréstimos. Usa o repositório recebido pelo construtor.
public class EmprestimoService : IEmprestimoService
{
    private readonly IEmprestimoRepository _repositorio;
    private readonly IUsuarioRepository _usuarioRepositorio;
    private readonly ILivroRepository _livroRepositorio;

    public EmprestimoService(
        IEmprestimoRepository repositorio,
        IUsuarioRepository usuarioRepositorio,
        ILivroRepository livroRepositorio)
    {
        _repositorio = repositorio;
        _usuarioRepositorio = usuarioRepositorio;
        _livroRepositorio = livroRepositorio;
    }

    public async Task<IEnumerable<Emprestimo>> ListarTodosAsync()
    {
        return await _repositorio.ListarTodosAsync();
    }

    public async Task<Emprestimo?> ObterPorIdAsync(int id)
    {
        return await _repositorio.ObterPorIdAsync(id);
    }

    public async Task<Emprestimo> CriarAsync(Emprestimo emprestimo)
    {
        _repositorio.Adicionar(emprestimo);
        await _repositorio.SalvarAlteracoesAsync();

        return emprestimo;
    }

    public async Task<bool> AtualizarAsync(Emprestimo emprestimo)
    {
        // Validação: o empréstimo precisa existir (no código de referência, PUT sem registro retorna NotFound)
        var existente = await _repositorio.ObterPorIdAsync(emprestimo.Id);
        if (existente is null)
        {
            return false;
        }

        existente.UsuarioId = emprestimo.UsuarioId;
        existente.LivroId = emprestimo.LivroId;
        // A data do empréstimo é mantida: ela é definida na criação e não vem no PUT.

        await _repositorio.SalvarAlteracoesAsync();
        return true;
    }

    public async Task<bool> ExcluirAsync(int id)
    {
        // Validação: o empréstimo precisa existir (no código de referência, DELETE sem registro retorna NotFound)
        var existente = await _repositorio.ObterPorIdAsync(id);
        if (existente is null)
        {
            return false;
        }

        _repositorio.Remover(existente);
        await _repositorio.SalvarAlteracoesAsync();
        return true;
    }

    public async Task<string?> ValidarReferenciasAsync(int usuarioId, int livroId)
    {
        if (await _usuarioRepositorio.ObterPorIdAsync(usuarioId) is null)
        {
            return $"Usuário com Id {usuarioId} não encontrado.";
        }

        if (await _livroRepositorio.ObterPorIdAsync(livroId) is null)
        {
            return $"Livro com Id {livroId} não encontrado.";
        }

        return null;
    }
}