using Microsoft.EntityFrameworkCore;
using NftMkpAPI.Data;
using NftMkpAPI.Models;

namespace NftMkpAPI.Services;

public class ItemsService
{
    private readonly ApiDbContext _context;
    public ItemsService(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<List<Item>> GetAllItemsAsync(int page, int size)
    {
        var skip = page * size;
        var sliceSize = size > 0 ? size : 10;
        return await _context.Items.Include(i => i.Nft)
            .OrderBy(i=>i.Item_Id)
            .Where(i=>i.Is_Sold.Equals(false))
            .Skip(skip)
            .Take(sliceSize)
            .ToListAsync();
    }
}
