
using Domain.Entities;
using Domain.Enum;

namespace Application.Services.Tarefas;

public interface ITarefaService
{
    Task<Tarefa> CreateAsync(TarefaDTO tarefa);
    Task DeleteAsync(Guid tarefaId);
    Task<Tarefa> UpdateAsync(Tarefa tarefa);
    Task<Tarefa> GetTarefaByIdAsync(Guid tarefaId);
    Task<IEnumerable<Tarefa>> GetTarefasAsync();
    Task<IEnumerable<Tarefa>> GetTarefasByStatusAsync(int status);
    Task<IEnumerable<Tarefa>> GetTarefasByDataVencimentoAsync(DateTime dataVencimento);
}
