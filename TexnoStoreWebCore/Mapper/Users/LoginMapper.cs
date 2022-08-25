using TexnoStore.Core.Domain.Entities;
using TexnoStoreWebCore.Models.Users;

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
                Name = entity.Name,
                LastName = entity.LastName,
            }; 
        }

        public User Map(LoginRequestModel model)
        {
            return new User
            {
                Email = model.Email,
                PasswordHash = model.Password,
                LastName = model.LastName,
                Name = model.Name,
            };
        }

    }
}
