using Microsoft.AspNetCore.Mvc;
using Project.Services.Class;
using Project.Services.Interface;
using System.Collections.Generic; 
using Project.Models;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private  IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }


    [HttpGet("filter")]
    public IActionResult GetOrders([FromQuery] OrderQueryParams query)
    {
        var orders = _service.GetOrders(query);
        return Ok(orders);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var order = _service.GetById(id);

        if (order == null)
            return NotFound();

        return Ok(order);
    }


    [HttpPost]
    public IActionResult Create(Orders order)
    {
        var createdOrder = _service.Create(order);
        return Ok(createdOrder);
    }

   
    [HttpPut("{id}")]
    public IActionResult Update(int id, Orders order)
    {
        var updated = _service.Update(id, order);

        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

   
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);

        if (!deleted)
            return NotFound();

        return Ok("Deleted successfully");
    }
}