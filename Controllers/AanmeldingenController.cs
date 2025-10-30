using Microsoft.AspNetCore.Mvc;
using VeilingApi.Models;
using VeilingApi.Services;

namespace VeilingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AanmeldingenController : ControllerBase
{
    private readonly IAanmeldingService _svc;
    public AanmeldingenController(IAanmeldingService svc) => _svc = svc;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aanmelding>>> GetAll()
        => await _svc.GetAllAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Aanmelding>> Get(int id)
        => await _svc.GetByIdAsync(id) is { } x ? Ok(x) : NotFound();

    [HttpPost]
    public async Task<ActionResult<Aanmelding>> Create(Aanmelding dto)
    {
        var created = await _svc.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.AanmeldingId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Aanmelding dto)
        => await _svc.UpdateAsync(id, dto) ? NoContent() : BadRequest("Id mismatch");

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => await _svc.DeleteAsync(id) ? NoContent() : NotFound();
}
