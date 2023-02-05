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

    public async Task<List<Item>> GetAllItemsAsync()
    {
        return await _context.Items.Include(i => i.Nft).ToListAsync();
    }
}
