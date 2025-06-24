using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class TarefaEntityTypeConfiguration : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("Tarefa");
        builder.HasKey(t => t.TarefaId);
        builder.Property(t => t.TarefaId)
            .HasColumnName("tarefaId")
            .IsRequired();
        builder.Property(t => t.Titulo)
            .HasColumnName("titulo")
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasColumnName("descricao")
            .IsRequired();
        builder.Property(t => t.StatusTarefa)
            .HasColumnName("status")
            .HasConversion<int>()
            .IsRequired();
        builder.Property(t => t.DataVencimento)
       .HasColumnName("DataVencimento")
       .IsRequired();
    }
}
