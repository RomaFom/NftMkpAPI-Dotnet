using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NftMkpAPI.Models;

public class Item : BaseEntity
{
    [JsonPropertyName("item_id")]
    [Column("item_id")]
    public int Item_Id { get; set; }

    [JsonPropertyName("price")]
    [Column("price")]
    public double Price { get; set; }

    [JsonPropertyName("listing_price")]
    [Column("listing_price")]
    public double Listing_Price { get; set; }

    [JsonPropertyName("seller")]
    [Column("seller")]
    public string Seller { get; set; } = string.Empty;

    [JsonPropertyName("is_sold")]
    [Column("is_sold")]
    public bool Is_Sold { get; set; }

    [JsonPropertyName("total_price")]
    [Column("total_price")]
    public double Total_Price { get; set; }

    [JsonPropertyName("nft_id")]
    [Column("nft_id")]
    public int Nft_Id { get; set; }

    [JsonPropertyName("createdAt")]
    [Column("createdAt")]
    public string Created_At { get; set; } = string.Empty;

    [JsonPropertyName("updatedAt")]
    [Column("updatedAt")]
    public string Updated_At { get; set; } = string.Empty;


    [ForeignKey("Nft_Id")]
    [JsonPropertyName("nft")]
    public Nft Nft { get; set; }
}
