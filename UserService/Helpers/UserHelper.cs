using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Helpers
{
    public class UserHelper(AppDbContext dbContext)
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<User?> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User?> Login(LoginCreateDto user)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.NIM == user.NIM && x.Password == user.Password);
        }
    }
}
