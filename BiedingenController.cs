using Microsoft.AspNetCore.Mvc;
using VeilingApi.Models;
using VeilingApi.Services;

namespace VeilingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BiedingenController : ControllerBase
{
    private readonly IBiedingService _svc;
    public BiedingenController(IBiedingService svc) => _svc = svc;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bieding>>> GetAll()
        => await _svc.GetAllAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Bieding>> Get(int id)
        => await _svc.GetByIdAsync(id) is { } x ? Ok(x) : NotFound();

    [HttpPost]
    public async Task<ActionResult<Bieding>> Create(Bieding dto)
    {
        var created = await _svc.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.BiedingId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Bieding dto)
        => await _svc.UpdateAsync(id, dto) ? NoContent() : BadRequest("Id mismatch");

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => await _svc.DeleteAsync(id) ? NoContent() : NotFound();
}
