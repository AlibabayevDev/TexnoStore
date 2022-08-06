using System.ComponentModel.DataAnnotations;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Models.Users
{
    public class UserViewModel :BaseEntity
    {
        public User user { get; set; }
        public LoginRequestModel loginModel { get; set; }
        public RegistrationModel RegistrationModel { get; set; }
        public string ConfirmPassword { get; set; }
        public string ErrorMessage { get; set; }
    }
}
