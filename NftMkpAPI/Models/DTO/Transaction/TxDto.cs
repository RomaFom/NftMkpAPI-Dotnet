using System.Text.Json.Serialization;
using NftMkpAPI.Models.DTO.User;

namespace NftMkpAPI.Models.DTO.Transaction;

public class TxDto
{
    [JsonPropertyName("sender")]
    public string Sender { get; set; } = String.Empty;
    
    [JsonPropertyName("tx_hash")]
    public string Tx_Hash { get; set; } = String.Empty;

    [JsonPropertyName("item_id")]
    public int Item_Id { get; set; }
    
    [JsonPropertyName("action")]
    public ActionType Action { get; set; }
    
    [JsonPropertyName("user")]
    public PublicUserDto User { get; set; }
    
    [JsonPropertyName("item")]
    public Item Item { get; set; }
}