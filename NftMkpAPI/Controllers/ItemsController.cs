using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NftMkpAPI.Models;
using NftMkpAPI.Services;

namespace NftMkpAPI.Controllers;

[Route("items/")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ItemsService _itemsService;

    public ItemsController(ItemsService itemsService)
    {
        _itemsService = itemsService;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<Item>>> GetAll([FromQuery] int page, int size)
    {
        var items = await _itemsService.GetAllItemsAsync(page,size);
        return Ok(items);
    }

    [HttpGet("owner/{wallet}")]
    public async Task<ActionResult<List<Item>>> GetByOwner([FromQuery] int page, int size,string wallet)
    {
        if (wallet == null)
        {
            return BadRequest(new { error = "Must provide wallet address" });
        };
        
        var items = await _itemsService.GetItemsByOwnerAsync(page,size,wallet);
        return Ok(items);
    }
}
