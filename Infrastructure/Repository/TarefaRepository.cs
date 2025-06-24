using Domain.Entities;
using Domain.Enum;
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

    public async Task<Tarefa> GetTarefaByIdAsync(Guid tarefaId) => 
        await _context.Tarefas.FirstOrDefaultAsync(x => x.TarefaId == tarefaId) ?? null!;

    public async Task<IEnumerable<Tarefa>> GetTarefasAsync() => 
        await _context.Tarefas.ToListAsync();

    public async Task<IEnumerable<Tarefa>> GetTarefasByDataVencimentoAsync(DateTime dataVencimento) =>
        await _context.Tarefas
            .Where(x =>
                x.DataVencimento.Year == dataVencimento.Year &&
                x.DataVencimento.Month == dataVencimento.Month &&
                x.DataVencimento.Day == dataVencimento.Day)
            .ToListAsync();

    public async Task<IEnumerable<Tarefa>> GetTarefasByStatusAsync(StatusTarefa status) =>
        await _context.Tarefas.Where(x => x.StatusTarefa == status).ToListAsync();
   
    public async Task<Tarefa> UpdateAsync(Tarefa tarefa)
    {
        _context.Update(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }
}
