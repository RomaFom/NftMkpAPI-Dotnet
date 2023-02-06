using System.ComponentModel.DataAnnotations;

namespace NftMkpAPI.Models.DTO.User;

public class RegisterUserDto
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string? Password { get; set; }
}