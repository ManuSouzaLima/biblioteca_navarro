using biblioteca_navarro.Models;

namespace biblioteca_navarro.Services;

/// Implementação do serviço de empréstimos. Usa o repositório recebido pelo construtor.
public class EmprestimoService : IEmprestimoService
{
    private readonly IEmprestimoRepository _repositorio;

    public EmprestimoService(IEmprestimoRepository repositorio)
    {
        _repositorio = repositorio;
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
        existente.DataEmprestimo = emprestimo.DataEmprestimo;

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
}