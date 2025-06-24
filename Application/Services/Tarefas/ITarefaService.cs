
using Domain.Entities;

namespace Application.Services.Tarefas;

public interface ITarefaService
{
    Task<Tarefa> CreateAsync(TarefaDTO tarefa);
    Task DeleteAsync(Guid tarefaId);
    Task<Tarefa> UpdateAsync(Tarefa tarefa);
    Task<Tarefa> GetTarefaByIdAsync(Guid tarefaId);
    Task<IEnumerable<Tarefa>> GetTarefasAsync();
}
