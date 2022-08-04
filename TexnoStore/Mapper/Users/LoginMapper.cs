using TexnoStore.Core.Domain.Entities;
using TexnoStore.Models.Users;

namespace TexnoStore.Mapper.Users
{
    public class LoginMapper
    {
        public LoginRequestModel Map(User entity)
        {
            return new LoginRequestModel
            {
                Email = entity.Email,
                Password = entity.PasswordHash,
            }; 
        }

        public User Map(LoginRequestModel model)
        {
            return new User
            {
                Email = model.Email,
                PasswordHash = model.Password
            };
        }

    }
}
