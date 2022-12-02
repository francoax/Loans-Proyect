using Backend.Data.Generic;
using Backend.Dto;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess.DataUser
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(ThingsContext context) : base(context)
        {
        }

        public bool Exists(string username)
        {
            return context.Users.Any(u => u.Username == username);
        }

        public User? Get(UserForLoginDto user)
        {
            var username = user.username;
            var password = user.password;
            return context.Users.FirstOrDefault(us => us.Username == username && us.Password == password);
        }
    }
}
