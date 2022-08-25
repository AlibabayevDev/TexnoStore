using System.ComponentModel.DataAnnotations;

namespace TexnoStoreWebCore.Models.Users
{
    public class LoginRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

    
        public string Email { get; set; }

 
        public string Password { get; set; }
        public string RetypePassword { get; set; }
        public string Index(bool isMarried) => $"isMarried: {isMarried}";
    }

    public class LoginResponseModel
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
