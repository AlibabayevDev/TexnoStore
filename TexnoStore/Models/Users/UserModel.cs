﻿using System.ComponentModel.DataAnnotations;

namespace TexnoStore.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }

        [Display(Name = "Email"), MinLength(8), MaxLength(30), Required(ErrorMessage = "Длина не менее 6 символов")]
        public string Email { get; set; }


        [Display(Name = "Password"), MinLength(6), MaxLength(30), Required(ErrorMessage = "Длина пароля не менее 6 символов")]
        public string PasswordHash { get; set; }
    }
}
