using System.ComponentModel.DataAnnotations;

namespace TexnoStore.Models.Users
{
    public class LoginRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Email"), MinLength(10), MaxLength(30), Required(ErrorMessage = "Email length is at least 10 characters")]
        public string Email { get; set; }

        [Display(Name = "Password"), MinLength(8), MaxLength(30), Required(ErrorMessage = "Password length is at least 8 characters")]
        public string Password { get; set; }
        public string RetypePassword { get; set; }
    }
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
