using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _itemsService.GetAllItemsAsync();
        return Ok(items);
    }
}
