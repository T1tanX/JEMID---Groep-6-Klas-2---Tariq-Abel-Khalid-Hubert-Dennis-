using Microsoft.AspNetCore.Mvc;
using VeilingApi.Models;
using VeilingApi.Services;

namespace VeilingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AanvoerdersController : ControllerBase
{
    private readonly IAanvoerderService _svc;
    public AanvoerdersController(IAanvoerderService svc) => _svc = svc;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aanvoerder>>> GetAll()
        => await _svc.GetAllAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Aanvoerder>> Get(int id)
        => await _svc.GetByIdAsync(id) is { } x ? Ok(x) : NotFound();

    [HttpPost]
    public async Task<ActionResult<Aanvoerder>> Create(Aanvoerder dto)
    {
        var created = await _svc.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.AanvoerderId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Aanvoerder dto)
        => await _svc.UpdateAsync(id, dto) ? NoContent() : BadRequest("Id mismatch");

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => await _svc.DeleteAsync(id) ? NoContent() : NotFound();
}
