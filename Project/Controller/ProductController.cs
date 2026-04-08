using Microsoft.AspNetCore.Mvc;
using Project.Services.Interface;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private IProductService service;

    public ProductController(IProductService s)
    {
        service = s;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] ProductQueryParams query)
    {
        var products = service.Get(query);
        return Ok(products);
    }

    [HttpPost]
    public IActionResult Create(Product p)
    {
        return Ok(service.Create(p));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product product)
    {
        var result = service.Update(id, product);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result) return NotFound();

        return Ok();
    }
}