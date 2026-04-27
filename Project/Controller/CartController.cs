using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Interface;

[ApiController]
[Route("api/[controller]")]
[Authorize]   
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;
    public CartController(ICartService cartService) { _cartService = cartService; }

    private int GetUserId()
        => int.Parse(User.Claims.First(cart => cart.Type == "UserId").Value);

    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var cart = await _cartService.GetCartAsync(GetUserId());
        if (cart == null)
            return Ok(new {
                Items = new List<object>(), TotalAmount = 0, TotalItems = 0
            });
        return Ok(cart);
    }


    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] AddToCartDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var cart = await _cartService.AddToCartAsync(GetUserId(), dto);
        return Ok(cart);
    }

    
    [HttpPut("update/{productId}")]
    public async Task<IActionResult> UpdateQuantity(int productId, [FromQuery] int quantity)
    {
        var cart = await _cartService.UpdateQuantityAsync(GetUserId(), productId, quantity);
        if (cart == null) return NotFound(new { Message = "Item not found in cart" });
        return Ok(cart);
    }

    
    [HttpDelete("remove/{productId}")]
    public async Task<IActionResult> Remove(int productId)
    {
        var removed = await _cartService.RemoveFromCartAsync(GetUserId(), productId);
        if (!removed) return NotFound(new { Message = "Item not found in cart" });
        return Ok(new { Message = "Item removed" });
    }

    
    [HttpDelete("clear")]
    public async Task<IActionResult> Clear()
    {
        await _cartService.ClearCartAsync(GetUserId());
        return Ok(new { Message = "Cart cleared" });
    }

   
    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout([FromBody] CheckoutDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var order = await _cartService.CheckoutAsync(GetUserId(), dto);
        return Ok(new { Message = "Order placed! Payment is being processed.", Order = order });
    }
}