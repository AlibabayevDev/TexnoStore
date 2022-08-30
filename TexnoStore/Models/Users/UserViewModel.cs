using System.ComponentModel.DataAnnotations;
using TexnoStore.Core.Domain.Entities;
using TexnoStoreWebCore.Models;

namespace TexnoStore.Models.Users
{
    public class UserViewModel :BaseModel
    {
        public User user { get; set; }
        public LoginRequestModel loginModel { get; set; }
        public RegistrationModel RegistrationModel { get; set; }
        public string ConfirmPassword { get; set; }
        public string ErrorMessage { get; set; }
    }
}
