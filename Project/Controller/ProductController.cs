using Microsoft.AspNetCore.Mvc;
using Project.Services.Interface;
using Project.Models;
 

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

   
    [HttpGet]
    public IActionResult Get([FromQuery] ProductQueryParams query)
    {
        var products = _service.Get(query); 
        return Ok(products);
    }

   
    [HttpPost]
    public IActionResult Create([FromBody] ProductDTO dto)
    {
        var created = _service.Create(dto); 
        return Ok(created);
    }

    
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] ProductDTO dto)
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
        return Ok();
    }
}