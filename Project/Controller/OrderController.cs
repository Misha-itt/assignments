using Microsoft.AspNetCore.Mvc;
using Project.Services.Interface;
using Microsoft.AspNetCore.RateLimiting;
using Project.Models;


[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

 
    [HttpGet("filter")]
    [EnableRateLimiting("Fixed")]
    public IActionResult GetOrders([FromQuery] OrderQueryParams query)
    {
        var orders = _service.GetOrders(query);
        return Ok(orders);
    }

  
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var order = _service.GetById(id); 
        if (order == null) return NotFound();
        return Ok(order);
    }

   
    [HttpPost]
    public IActionResult Create([FromBody] OrdersDTO dto)
    {
        var created = _service.Create(dto); 
        return Ok(created);
    }

   
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] OrdersDTO dto)
    {
        var updated = _service.Update(id, dto); 
        if (updated == null) return NotFound();
        return Ok(updated);
    }

   
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);
        if (!deleted) return NotFound();
        return Ok("Deleted successfully");
    }
}