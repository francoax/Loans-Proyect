﻿namespace Backend.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public Role Role { get; set; }
    }

}