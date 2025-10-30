using Microsoft.AspNetCore.Mvc;
using VeilingApi.Models;
using VeilingApi.Services;

namespace VeilingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VeilingenController : ControllerBase
{
    private readonly IVeilingService _svc;
    public VeilingenController(IVeilingService svc) => _svc = svc;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Veiling>>> GetAll()
        => await _svc.GetAllAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Veiling>> Get(int id)
        => await _svc.GetByIdAsync(id) is { } x ? Ok(x) : NotFound();

    [HttpPost]
    public async Task<ActionResult<Veiling>> Create(Veiling dto)
    {
        var created = await _svc.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.VeilingId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Veiling dto)
        => await _svc.UpdateAsync(id, dto) ? NoContent() : BadRequest("Id mismatch");

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => await _svc.DeleteAsync(id) ? NoContent() : NotFound();
}
