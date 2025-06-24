using Domain.Entities;
using Domain.Enum;

namespace Domain.Repository;

public interface ITarefaRepository
{
    Task<Tarefa> CreateAsync(Tarefa tarefa);
    Task DeleteAsync(Tarefa tarefa);
    Task<Tarefa> UpdateAsync(Tarefa tarefa);
    Task<IEnumerable<Tarefa>> GetTarefasAsync();
    Task<Tarefa> GetTarefaByIdAsync(Guid tarefaId);
    Task<IEnumerable<Tarefa>> GetTarefasByStatusAsync(StatusTarefa status);
    Task<IEnumerable<Tarefa>> GetTarefasByDataVencimentoAsync(DateTime dataVencimento);

}
