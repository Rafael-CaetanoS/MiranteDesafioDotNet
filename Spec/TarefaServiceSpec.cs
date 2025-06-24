using Application.Services.Tarefas;
using Domain.Entities;
using Domain.Enum;
using Domain.Repository;
using Moq;

namespace Spec;

public class TarefaServiceSpec
{
    private readonly Mock<ITarefaRepository> _repository;
    private readonly TarefaService _service;

    public TarefaServiceSpec()
    {
        _repository = new Mock<ITarefaRepository>();
        _service = new TarefaService(_repository.Object);
    }

    [Fact]
    public async Task RetornaListaDeTarefasEsperada()
    {
        var tarefas = SetupTarefa();
        _repository
         .Setup(x => x.GetTarefasAsync())
         .ReturnsAsync(tarefas);
        
        var result = await _service.GetTarefasAsync();
        Assert.NotNull(result );
        Assert.Equal(result.Count(), tarefas.Count());
        var primeiraTarefa = tarefas.FirstOrDefault();
        var primeiroResultado = result.FirstOrDefault();
        Assert.NotNull( primeiroResultado );
        Assert.NotNull(primeiraTarefa);
        Assert.Equal(primeiraTarefa.Titulo, primeiroResultado.Titulo);
        Assert.Equal(primeiraTarefa.Descricao, primeiroResultado.Descricao);
        Assert.Equal(primeiraTarefa.StatusTarefa, primeiroResultado.StatusTarefa);
        Assert.Equal(primeiraTarefa.DataVencimento, primeiroResultado.DataVencimento);
    }

    [Fact]
    public async Task RetornaListaDeTarefasByStatusEsperada()
    {
        var status = 1;
        var tarefas = SetupTarefa();
        _repository
         .Setup(x => x.GetTarefasAsync())
         .ReturnsAsync(tarefas.Where(x=> x.StatusTarefa == (StatusTarefa)status));
        var result = await _service.GetTarefasByStatusAsync(status);
        Assert.NotNull(result);
        Assert.Equal(result.Count(), tarefas.Count());
        var primeiraTarefa = tarefas.FirstOrDefault();
        var primeiroResultado = result.FirstOrDefault();
        Assert.NotNull(primeiroResultado);
        Assert.NotNull(primeiraTarefa);
        Assert.Equal(primeiraTarefa.Titulo, primeiroResultado.Titulo);
        Assert.Equal(primeiraTarefa.Descricao, primeiroResultado.Descricao);
        Assert.Equal(primeiraTarefa.StatusTarefa, primeiroResultado.StatusTarefa);
        Assert.Equal(primeiraTarefa.DataVencimento, primeiroResultado.DataVencimento);
    }

    [Fact]
    public async Task RetornaListaDeTarefasByStatusVazia()
    {
        var tarefas = SetupTarefa();
        _repository
         .Setup(x => x.GetTarefasAsync())
         .ReturnsAsync([]);
        var result = await _service.GetTarefasByStatusAsync(1);
        Assert.Empty(result);
    }


    private static List<Tarefa> SetupTarefa()
    {
        return new List<Tarefa>
        {
            new Tarefa
            {
                TarefaId = Guid.NewGuid(),
                Titulo = "Tarefa 1",
                Descricao = "Primeira tarefa de teste",
                StatusTarefa = (StatusTarefa) 0,
                DataVencimento = new DateTime(2025, 06, 23, 10, 0, 0)
            },
            new Tarefa
            {
                TarefaId = Guid.NewGuid(),
                Titulo = "Tarefa 2",
                Descricao = "Segunda tarefa de teste",
                StatusTarefa = (StatusTarefa) 1,
                DataVencimento = new DateTime(2025, 06, 23, 10, 0, 0)
            },
            new Tarefa
            {
                TarefaId = Guid.NewGuid(),
                Titulo = "Tarefa 3",
                Descricao = "Terceira tarefa de teste",
                StatusTarefa = (StatusTarefa) 0,
                DataVencimento = new DateTime(2025, 06, 23, 10, 0, 0)
            }
        };
    }
}