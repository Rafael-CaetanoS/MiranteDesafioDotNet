using Application.Services.Tarefas;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TarefaApi.Controllers;

[ApiController]
[Route("api/Tarefa")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _service;

    public TarefaController(ITarefaService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TarefaDTO tarefa)
    {
        var result = await _service.CreateAsync(tarefa);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetTarefas() 
    {
        var tarefas = await _service.GetTarefasAsync();
        return Ok(tarefas);
    }

    [HttpGet("byid/{tarefaId}")]
    public async Task<IActionResult> GetTarefasById([FromRoute] string tarefaId)
    {
        var tarefas = await _service.GetTarefaByIdAsync(Guid.Parse(tarefaId));
        return Ok(tarefas);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTarefa(Tarefa tarefa)
    {
        var result = await _service.UpdateAsync(tarefa);
        return Ok(result);
    }

    [HttpDelete("{tarefaId}")]
    public async Task<IActionResult> DeleteTarefa([FromRoute] string tarefaId)
    {
        await _service.DeleteAsync(Guid.Parse(tarefaId));
        return Ok();
    }
}
