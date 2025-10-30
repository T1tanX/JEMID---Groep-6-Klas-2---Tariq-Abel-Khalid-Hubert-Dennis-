using Microsoft.AspNetCore.Mvc;
using VeilingApi.Models;
using VeilingApi.Services;

namespace VeilingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VeilingProductsController : ControllerBase
{
    private readonly IVeilingProductService _svc;
    public VeilingProductsController(IVeilingProductService svc) => _svc = svc;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VeilingProduct>>> GetAll()
        => await _svc.GetAllAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<VeilingProduct>> Get(int id)
        => await _svc.GetByIdAsync(id) is { } x ? Ok(x) : NotFound();

    [HttpPost]
    public async Task<ActionResult<VeilingProduct>> Create(VeilingProduct dto)
    {
        try
        {
            var created = await _svc.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.VeilingProductId }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, VeilingProduct dto)
    {
        try
        {
            return await _svc.UpdateAsync(id, dto) ? NoContent() : BadRequest("Id mismatch");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => await _svc.DeleteAsync(id) ? NoContent() : NotFound();
}
