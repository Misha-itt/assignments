using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        return product == null ? NotFound() : Ok(product);
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create([FromBody] ProductDTO dto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var created = _service.Create(dto); 
        return Ok(created);
    }

    [HttpGet("product-sales-summary")]
    public IActionResult GetProductSalesSummary()
    {
       
        return Ok(_service.GetProductSalesSummary());
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Update(int id, [FromBody] ProductDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var updated = _service.Update(id, dto); 
        if (updated == null) return NotFound();
        return Ok(updated);
    }

  
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);
        if (!deleted) return NotFound();
        return Ok();
    }
}