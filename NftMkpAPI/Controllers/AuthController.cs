using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NftMkpAPI.Models;
using NftMkpAPI.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NftMkpAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;
    //private readonly JwtConfig _jwtConfig;

    public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
        //_jwtConfig = jwtConfig;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto requestDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user_exists = await _userManager.FindByEmailAsync(requestDto.Email);
        if (user_exists != null)
        {
            return BadRequest(new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "Email already exists"
                }
            });
        }

        var new_user = new IdentityUser()
        {
            Email = requestDto.Email,
            UserName = requestDto.Email
        };

        var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);
        if (is_created.Succeeded)
        {
            var token = GenerateJwtToken(new_user);
            return Ok(new AuthResult()
            {
                Result = true,
                Token = token
            });
            // Generate token
        }

        return BadRequest(new AuthResult()
        {
            Result = false,
            Errors = new List<string>()
            {
                "Server error"
            }
        });
    }

    private string GenerateJwtToken(IdentityUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value!);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id",user.Id),
                new Claim(JwtRegisteredClaimNames.Sub,user.Email!),
                new Claim(JwtRegisteredClaimNames.Email,user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToUniversalTime().ToString())
            }),
            Expires = DateTime.Now.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);
        return jwtToken;
    }


}
