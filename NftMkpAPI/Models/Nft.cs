using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NftMkpAPI.Models;

public class Nft : BaseEntity
{
    [Key]
    [JsonPropertyName("nft_id")]
    public int Nft_Id { get; set; }

    [JsonPropertyName("owner")]
    public string Owner { get; set; } = string.Empty;

    [JsonPropertyName("image")]
    public string Image { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonIgnore]
    public Item Item { get; set; }
}
