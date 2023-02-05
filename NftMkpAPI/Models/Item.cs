using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NftMkpAPI.Models;

public class Item : BaseEntity
{
    [JsonPropertyName("item_id")]
    public int Item_Id { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("listing_price")]
    public double Listing_Price { get; set; }

    [JsonPropertyName("seller")]
    public string Seller { get; set; } = string.Empty;

    [JsonPropertyName("is_sold")]
    public bool Is_Sold { get; set; }

    [JsonPropertyName("total_price")]
    public double Total_Price { get; set; }

    [JsonPropertyName("nft_id")]
    public int Nft_Id { get; set; }

    [ForeignKey("Nft_Id")]
    [JsonPropertyName("nft")]
    public Nft Nft { get; set; }
}
