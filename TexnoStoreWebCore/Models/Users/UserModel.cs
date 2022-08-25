﻿using System.ComponentModel.DataAnnotations;

namespace TexnoStoreWebCore.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
