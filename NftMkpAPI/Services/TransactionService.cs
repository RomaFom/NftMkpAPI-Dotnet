using NftMkpAPI.Data;
using NftMkpAPI.Models;

namespace NftMkpAPI.Services;

public class TransactionService
{
    private readonly ApiDbContext _context;
    
    public TransactionService(ApiDbContext context)
    {
        _context = context;
    }

    public async Task AddTransactionAsync(Transaction tx)
    {
        await _context.Transactions.AddAsync(tx);
        await _context.SaveChangesAsync();
    }
    
}
