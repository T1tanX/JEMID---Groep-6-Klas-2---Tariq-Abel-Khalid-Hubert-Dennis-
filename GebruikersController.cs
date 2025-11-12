using Microsoft.AspNetCore.Mvc;
using VeilingApi.Models;
using VeilingApi.Services;

namespace VeilingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GebruikersController : ControllerBase
{
    private readonly IGebruikerService _svc;
    public GebruikersController(IGebruikerService svc) => _svc = svc;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gebruiker>>> GetAll()
        => await _svc.GetAllAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Gebruiker>> Get(int id)
        => await _svc.GetByIdAsync(id) is { } x ? Ok(x) : NotFound();

    [HttpPost]
    public async Task<ActionResult<Gebruiker>> Create(Gebruiker dto)
    {
        var created = await _svc.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.GebruikerId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Gebruiker dto)
        => await _svc.UpdateAsync(id, dto) ? NoContent() : BadRequest("Id mismatch");

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => await _svc.DeleteAsync(id) ? NoContent() : NotFound();
}
