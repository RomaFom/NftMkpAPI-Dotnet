using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NftMkpAPI.Models;
using NftMkpAPI.Models.DTO;
using NftMkpAPI.Models.DTO.User;
using NftMkpAPI.Services;

namespace NftMkpAPI.Controllers;

[Route("auth/")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IConfiguration _configuration;

    public AuthController(UserService userService,IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("get-user"), Authorize]
    public async Task<ActionResult<PublicUserDto>> GetUser()
    {
        var userEmail = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;
        var user = await _userService.GetUserByEmailAsync(userEmail!);
        var response = new PublicUserDto
        {
            Id = user.Id,
            Email = user.Email
        };
        return Ok(response);
    }

    [HttpPost("login"),AllowAnonymous]
    public async Task<ActionResult<TokenDto>> Login([FromBody] RegisterUserDto loginDto)
    {
        if (loginDto is null)
        {
            return BadRequest(new { error = "Login Data Is Empty" });
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(new { error = ModelState });
        }
        
        var user = await _userService.GetUserByEmailAsync(loginDto.Email);
        if (user == null)
        {
            return NotFound(new { error = "User Not Found" });
        }
        if (!BCrypt.Net.BCrypt.Verify(loginDto.Password,user.Password))
        {
            return Unauthorized(new { error = "Wrong Email or Password" });
        }
        var jwt = new TokenDto
        {
            token = GenerateToken(user)
        };
        return Ok(jwt);
        
    }

    [HttpPost("registration"),AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto newUser)
    {
        if (newUser is null)
        {
            return BadRequest(new { error = "User is empty" });
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(new { error = ModelState });
        }

        var isExists = await _userService.GetUserByEmailAsync(newUser.Email);
        if (isExists != null)
        {
            return BadRequest(new { error = "User Already Exists" });
        }
        
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

        var user = new User
        {
            Password = passwordHash,
            Email = newUser.Email
        };
        await _userService.AddUserAsync(user);
        var jwt = new TokenDto
        {
            token = GenerateToken(user)
        };
        return Ok(jwt);
    }

    private string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("UserId", user.Id!.ToString()),
            new Claim("Email", user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signIn);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    [HttpGet("test-protected"),Authorize]
    public async Task<ActionResult> TestProtected()
    {
        return Ok("Works");

    }

}