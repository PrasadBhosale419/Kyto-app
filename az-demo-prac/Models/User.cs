﻿namespace az_demo_prac.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; }

        public double Phone { get; set; }

        public string Password { get; set; }

        public int AssignedTask { get; set; }

        public bool IsDeprecated { get; set; } 
    }
}
