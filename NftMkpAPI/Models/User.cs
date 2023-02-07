using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace NftMkpAPI.Models;

[Index(nameof(Email), IsUnique = true)]
public class User : BaseEntity
{
    [JsonPropertyName("email")]
    [Column("email")]
    public string Email { get; set; } = string.Empty;
    
    [JsonPropertyName("password")]
    [Column("password")]
    public string Password { get; set; } = string.Empty;
}