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

        public async Task<IEnumerable<User>> GetUserByIds(IEnumerable<int> ids)
        {
            return await _dbContext.Users.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetEligibleUsers(IEnumerable<int> ids)
        {
            return await _dbContext.Users.Where(x => !ids.Contains(x.Id) && x.Role == false).ToListAsync();
        }

        public async Task<User?> Login(LoginCreateDto user)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.NIM == user.NIM && x.Password == user.Password);
        }
    }
}
