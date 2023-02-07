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
}
