using Microsoft.AspNetCore.Authorization;
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

 
    [HttpGet]
    [EnableRateLimiting("fixed")]
    public IActionResult GetOrders([FromQuery] OrderQueryParams query)
    {
        var orders = _service.GetOrders(query);
        return Ok(orders);
    }

  
   
    [HttpPost]
    [Authorize]
    public   IActionResult Create([FromBody] OrdersDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var createdOrder = _service.CreateAsync(dto); 
        return Ok(createdOrder);
    }

   
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] OrdersDTO dto)
    {
        var updated = _service.Update(id, dto); 
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpGet("order-summary")]
    public IActionResult GetOrderSummary()
    {
        return Ok(_service.GetOrderSummary());
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);
        if (!deleted) return NotFound();
        return Ok("Deleted successfully");
    }
}