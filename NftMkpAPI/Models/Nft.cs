using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NftMkpAPI.Models;

public class Nft : BaseEntity
{
    [JsonPropertyName("nft_id")]
    [Column("nft_id")]
    public int Nft_Id { get; set; }

    [JsonPropertyName("owner")]
    [Column("owner")]
    public string Owner { get; set; } = string.Empty;

    [JsonPropertyName("image")]
    [Column("image")]
    public string Image { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("createdAt")]
    [Column("createdAt")]
    public string Created_At { get; set; } = string.Empty;

    [JsonPropertyName("updatedAt")]
    [Column("updatedAt")]
    public string Updated_At { get; set; } = string.Empty;

    [JsonIgnore]
    public Item Item { get; set; }
}
