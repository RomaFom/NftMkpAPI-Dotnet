using Microsoft.AspNetCore.Mvc;
using NftMkpAPI.Models;
using NftMkpAPI.Services;

namespace NftMkpAPI.Controllers;

[Route("api/items")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ItemsService _itemsService;

    public ItemsController(ItemsService itemsService)
    {
        _itemsService = itemsService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<Item>>> GetAll()
    {
        var items = await _itemsService.GetAllItemsAsync();
        return Ok(items);
    }
}
