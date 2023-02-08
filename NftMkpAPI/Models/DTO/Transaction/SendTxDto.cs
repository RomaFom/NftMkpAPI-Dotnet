using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NftMkpAPI.Models.DTO.Transaction;

public class SendTxDto
{
    [Required]
    [JsonPropertyName("sender")]
    public string Sender { get; set; }
    
    [Required]
    [JsonPropertyName("tx_hash")]
    public string Tx_Hash { get; set; }

    [Required]
    [JsonPropertyName("item_id")]
    public int Item_Id { get; set; }
}