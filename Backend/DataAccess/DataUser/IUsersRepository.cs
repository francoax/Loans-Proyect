using Backend.Data.Generic;
using Backend.Dto;
using Backend.Entities;

namespace Backend.DataAccess.DataUser
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        User? Get(UserForLoginDto user);
        bool Exists(string username);
    }
}
