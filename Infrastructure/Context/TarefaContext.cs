using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class TarefaContext : DbContext
{
    public TarefaContext(DbContextOptions options) : base(options)
    { }
   
    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TarefaContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
