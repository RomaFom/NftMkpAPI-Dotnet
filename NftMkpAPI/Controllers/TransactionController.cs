using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NftMkpAPI.Models;
using NftMkpAPI.Models.DTO.Transaction;
using NftMkpAPI.Services;

namespace NftMkpAPI.Controllers;

[Route("transaction/")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly TransactionService _transactionService;
    // private readonly ItemsService _itemsService;

    private static readonly HttpClient _nftApi = new()
    {
        BaseAddress = new Uri("http://localhost:8080")
    };

    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost("send")]
    [Authorize]
    public async Task<ActionResult> Send([FromBody] SendTxDto tx)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { error = ModelState });
        }
        var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value!;

        var newTx = new Transaction
        {
            Tx_Hash = tx.Tx_Hash,
            Sender = tx.Sender,
            User_Id = int.Parse(userId),
            Item_Id = tx.Item_Id,
            Action = tx.Action,
        };
        StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                item_id = tx.Item_Id
            }),
            Encoding.UTF8,
            "application/json"
        );
        await _transactionService.AddTransactionAsync(newTx);
        var res = await _nftApi.PostAsync("web3/update-item/" + tx.Item_Id,jsonContent);
        var jsonRes = await res.Content.ReadAsStringAsync();
        return Ok(jsonRes);
    }
    
    [HttpGet("get-transactions/{userId:int}")]
    public async Task<ActionResult<Transaction>> GetTransactions(int userId)
    {
        var transactions = await _transactionService.GetTransactionsByUserIdAsync(userId);
        return Ok(transactions);
    }
    


}