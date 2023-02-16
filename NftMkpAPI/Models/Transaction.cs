using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NftMkpAPI.Models;

public enum ActionType
{
    Buy,
    List,
}

public class Transaction : BaseEntity
{
    [JsonPropertyName("user_id")]
    [Column("user_id")]
    public int User_Id { get; set; }

    [JsonPropertyName("sender")]
    [Column("sender")]
    public string Sender { get; set; } = String.Empty;
    
    [JsonPropertyName("tx_hash")]
    [Column("tx_hash")]
    public string Tx_Hash { get; set; } = String.Empty;

    [JsonPropertyName("item_id")]
    [Column("item_id")]
    public int Item_Id { get; set; }
    
    [JsonPropertyName("action")]
    [Column("action")]
    public ActionType Action { get; set; }
    
    [ForeignKey("Item_Id")]
    [JsonPropertyName("item")]
    public Item Item { get; set; }


    [ForeignKey("User_Id")]
    [JsonPropertyName("user")]
    public User User { get; set; }
}


// export interface TxCreationAttrs {
//     user_id: number;
//     sender: string;
//     tx_hash: string;
//     wallet: string;
//     item_id: number;
// }