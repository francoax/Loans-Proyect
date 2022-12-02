using Backend.Data.Generic;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Backend.DataAccess.DataRol
{
    public class RolesRepository : IRolesRepository
    {
        private List<Role> roles = new List<Role> {
            new Role{ Id = 1, Description = "user"},
            new Role{ Id = 2, Description = "admin"}
        };

        public Role FindRole(int IdRole)
        {
            return roles.First(r => r.Id == IdRole);
        }

        public List<Role> GetAll()
        {
            return roles;
        }
        public Role GetRole(string role)
        {
            return roles.First(r => r.Description == role);
        }

        public Role GetRole(int IdRole)
        {
            return roles.First(r => r.Id == IdRole);
        }
    }
}
