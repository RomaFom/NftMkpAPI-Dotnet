using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NftMkpAPI.Models;

public class Transaction : BaseEntity
{
    [JsonPropertyName("user_id")]
    [Column("user_id")]
    public int User_Id { get; set; }
    
    [JsonPropertyName("sender")]
    [Column("sender")]
    public string Sender { get; set; }
    
    [JsonPropertyName("tx_hash")]
    [Column("tx_hash")]
    public string Tx_Hash { get; set; }
    
    // [JsonPropertyName("wallet")]
    // [Column("wallet")]
    // public string Wallet { get; set; }
    
    [JsonPropertyName("item_id")]
    [Column("item_id")]
    public string Item_Id { get; set; }
}


// export interface TxCreationAttrs {
//     user_id: number;
//     sender: string;
//     tx_hash: string;
//     wallet: string;
//     item_id: number;
// }