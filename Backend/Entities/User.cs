using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        [NotMapped]
        public Role Role { get; set; }
    }

}