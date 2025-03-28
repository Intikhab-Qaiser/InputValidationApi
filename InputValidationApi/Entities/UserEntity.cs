﻿namespace InputValidationApi.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PasswordHash { get; set; } // ❌ Should not go out
        public DateTime CreatedAt { get; set; }
    }
}
