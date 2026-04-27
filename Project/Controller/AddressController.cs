using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Interface;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AddressController : ControllerBase
{
    private readonly IAddressService _service;
    public AddressController(IAddressService service) { _service = service; }

    private int GetUserId()
        => int.Parse(User.Claims.First(c => c.Type == "UserId").Value);

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync(GetUserId()));

   
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var address = await _service.GetByIdAsync(id, GetUserId());
        return address == null ? NotFound() : Ok(address);
    }

   
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddressDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _service.CreateAsync(GetUserId(), dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AddressDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var updated = await _service.UpdateAsync(id, GetUserId(), dto);
        return updated == null ? NotFound() : Ok(updated);
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id, GetUserId());
        return deleted ? NoContent() : NotFound();
    }

    
    [HttpPatch("{id}/set-default")]
    public async Task<IActionResult> SetDefault(int id)
    {
        var ok = await _service.SetDefaultAsync(id, GetUserId());
        return ok ? Ok(new { Message = "Default address updated" }) : NotFound();
    }
}