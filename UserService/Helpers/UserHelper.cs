using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UserService.Data;
using UserService.Models;

namespace UserService.Helpers
{
    public class UserHelper
    {
        private readonly AppDbContext _dbContext;

        public UserHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Id == id);
        }

        public User? Login(Login user)
        {
            return _dbContext.Users.FirstOrDefault(x => x.NIM == user.NIM && x.Password == user.Password);
        }
    }
}
