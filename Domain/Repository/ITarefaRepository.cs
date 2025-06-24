using Domain.Entities;

namespace Domain.Repository;

public interface ITarefaRepository
{
    Task<Tarefa> CreateAsync(Tarefa tarefa);
    Task DeleteAsync(Tarefa tarefa);
    Task<Tarefa> UpdateAsync(Tarefa tarefa);
    Task<Tarefa> GetTarefaByIdAsync(Guid tarefaId);
    Task<IEnumerable<Tarefa>> GetTarefasAsync();
}
