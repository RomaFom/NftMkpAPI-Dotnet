using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NftMkpAPI.Data;
using NftMkpAPI.Models;

namespace NftMkpAPI.Services;

public class UserService
{
    private readonly ApiDbContext _context;
    
    public UserService(ApiDbContext context)
    {
        _context = context;
    }

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
         await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        return user;
    }


}