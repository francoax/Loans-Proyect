using Backend.Data.Generic;
using Backend.Entities;

namespace Backend.DataAccess.DataRol
{
    public interface IRolesRepository
    {
        List<Role> GetAll();
        Role GetRole(string role);
        Role GetRole(int IdRole);
        Role FindRole (int IdRole);
    }
}
