using System.Text.Json.Serialization;

namespace NftMkpAPI.Models.DTO.User;

public class PublicUserDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
}