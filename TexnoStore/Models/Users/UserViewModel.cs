using System.ComponentModel.DataAnnotations;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Models.Users
{
    public class UserViewModel
    {
        public User user { get; set; }
        public LoginRequestModel loginModel { get; set; }
        public string ConfirmPassword { get; set; }
        public string ErrorMessage { get; set; }
    }
}
