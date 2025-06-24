using Domain.Enum;

namespace Application.Services.Tarefas;

public sealed record TarefaDTO(string Titulo, string Descricao, DateTime DataVencimento);

