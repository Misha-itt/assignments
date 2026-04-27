using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Interface;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class WishlistController : ControllerBase
{
    private readonly IWishlistService _service;
    public WishlistController(IWishlistService service)
    {
        _service = service; 
    }

    private int GetUserId()
        => int.Parse(User.Claims.First(c => c.Type == "UserId").Value);

   
    [HttpGet]
    public async Task<IActionResult> GetWishlist()
    {
        var wishlist = await _service.GetWishlistAsync(GetUserId());
        if (wishlist == null) return Ok(new { Items = new List<object>(), TotalItems = 0 });
        return Ok(wishlist);
    }

    [HttpPost("{productId}")]
    public async Task<IActionResult> Add(int productId)
    {
        var wishlist = await _service.AddAsync(GetUserId(), productId);
        return Ok(wishlist);
    }

  
    [HttpDelete("{productId}")]
    public async Task<IActionResult> Remove(int productId)
    {
        var removed = await _service.RemoveAsync(GetUserId(), productId);
        if (!removed) return NotFound(new { Message = "Product not in wishlist" });
        return Ok(new { Message = "Removed from wishlist" });
    }

 
    [HttpDelete("clear")]
    public async Task<IActionResult> Clear()
    {
        await _service.ClearAsync(GetUserId());
        return Ok(new { Message = "Wishlist cleared" });
    }

    
    [HttpGet("check/{productId}")]
    public async Task<IActionResult> Check(int productId)
    {
        var isIn = await _service.IsInWishlistAsync(GetUserId(), productId);
        return Ok(new { IsInWishlist = isIn });
    }
}