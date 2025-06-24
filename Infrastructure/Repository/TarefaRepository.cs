using Domain.Entities;
using Domain.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TarefaRepository : ITarefaRepository
{
    private readonly TarefaContext _context;

    public TarefaRepository(TarefaContext context)
    {
        _context = context;
    }

    public async Task<Tarefa> CreateAsync(Tarefa tarefa)
    {
        await _context.AddAsync(tarefa);
        _context.SaveChanges();
        return tarefa;
    }

    public async Task DeleteAsync(Tarefa tarefa)
    {
       _context.Remove(tarefa);
       await _context.SaveChangesAsync();
    }

    public async Task<Tarefa> GetTarefaByIdAsync(Guid tarefaId) => await _context.Tarefas.FirstOrDefaultAsync(x => x.TarefaId == tarefaId) ?? null!;

    public async Task<IEnumerable<Tarefa>> GetTarefasAsync() => await _context.Tarefas.ToListAsync();
    
    public async Task<Tarefa> UpdateAsync(Tarefa tarefa)
    {
        _context.Update(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }
}
