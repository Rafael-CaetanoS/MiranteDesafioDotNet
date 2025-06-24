using Domain.Entities;
using Domain.Enum;
using Domain.Repository;

namespace Application.Services.Tarefas;

public class TarefaService : ITarefaService
{
    public readonly ITarefaRepository _repository;

    public TarefaService(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Tarefa> CreateAsync(TarefaDTO tarefa)
    {
        var tarefaCriada = Tarefa.Criar(tarefa.Titulo, tarefa.Descricao, StatusTarefa.Pendente, tarefa.DataVencimento);
        var result = await _repository.CreateAsync(tarefaCriada);
        return result;
    }

    public async Task DeleteAsync(Guid tarefaId)
    {
        var tarefaresult = await _repository.GetTarefaByIdAsync(tarefaId);
        if (tarefaresult == null) 
        {
            throw new Exception("Tarefa não encontrada");
        }

        await _repository.DeleteAsync(tarefaresult);
    }

    public async Task<Tarefa> GetTarefaByIdAsync(Guid tarefaId)
    {
        var tarefaresult = await _repository.GetTarefaByIdAsync(tarefaId);
        if (tarefaresult == null) 
            throw new Exception("Tarefa não encontrada");

        return tarefaresult;
    }

    public async Task<IEnumerable<Tarefa>> GetTarefasAsync()
    {
        var tarefas = await _repository.GetTarefasAsync();
        if (!tarefas.Any())
        {
            return [];
        }

        return tarefas;
    }

    public async Task<Tarefa> UpdateAsync(Tarefa tarefa)
    {
        var tarefaById = await _repository.GetTarefaByIdAsync(tarefa.TarefaId);
        if (tarefaById == null)
        {
            throw new Exception("Tarefa não encontrada");
        }

        tarefaById.Atualizar(tarefa.Titulo, tarefa.Descricao, tarefa.StatusTarefa, tarefa.DataVencimento);
        var result = await _repository.UpdateAsync(tarefaById);
        return result;
    }
}
