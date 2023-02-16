using Microsoft.EntityFrameworkCore;
using NftMkpAPI.Data;
using NftMkpAPI.Models;
using NftMkpAPI.Models.DTO.Transaction;
using NftMkpAPI.Models.DTO.User;

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

    public async Task<List<TxDto>> GetTransactionsByUserIdAsync(int userId)
    {
        return await _context.Transactions
            .Include(tx => tx.User)
            .Include(tx=>tx.Item)
            .Include(tx=>tx.Item.Nft)
            .Where(tx => tx.User_Id.Equals(userId))
            .Select(tx => new TxDto
            {
                Sender = tx.Sender,
                Tx_Hash = tx.Tx_Hash,
                Item_Id = tx.Item_Id,
                Action = tx.Action,
                User = new PublicUserDto
                {
                    Id = tx.User.Id,
                    Email = tx.User.Email,
                },
                Item = tx.Item

            })
            .ToListAsync();
    }

}
