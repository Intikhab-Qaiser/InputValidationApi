﻿namespace InputValidationApi.Models
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "User" or "Admin"
        public DateTime? CreatedAt { get; set; }
    }
}
