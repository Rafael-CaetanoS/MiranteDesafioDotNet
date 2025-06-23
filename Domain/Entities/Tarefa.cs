using Domain.Enum;

namespace Domain.Entities;

public class Tarefa
{
    public Guid TarefaId { get; set; }
    
    public string? Titulo { get; set; }

    public string? Descricao { get; set; }

    public StatusTarefa StatusTarefa { get; set; }

    public DateTime DataVencimento { get; set; }

    public Tarefa()
    { }

    public Tarefa(Guid tarefaId, string titulo, string descricao, StatusTarefa status, DateTime dataVencimento)
    {
        TarefaId = tarefaId;
        Titulo = titulo;
        Descricao = descricao;
        StatusTarefa = status;
        DataVencimento = dataVencimento;
    }

    public static Tarefa Criar(string titulo, string descricao, StatusTarefa status, DateTime dataVencimento)
    {
        if (string.IsNullOrEmpty(titulo)) 
            throw new ArgumentNullException(nameof(titulo)); 

        if(string.IsNullOrEmpty(descricao))
            throw new ArgumentNullException(nameof(descricao));

        if(status != StatusTarefa.EmAndamento 
            || status != StatusTarefa.Concluido
            || status != StatusTarefa.Pendente) 
            throw new ArgumentNullException(nameof(status));

       if(dataVencimento == DateTime.MinValue)
        {
            throw new ArgumentNullException(nameof(dataVencimento));
        }
        return new Tarefa(Guid.Empty, titulo, descricao, status, dataVencimento);
    }
}
