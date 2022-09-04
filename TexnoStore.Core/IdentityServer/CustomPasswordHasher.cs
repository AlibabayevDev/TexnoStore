using Microsoft.AspNetCore.Identity;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Utils;

namespace TexnoStore.IdentityServer
{
    public class CustomPasswordHasher : IPasswordHasher<User>
    {
        public string HashPassword(User user, string password)
        {
            password = SecurityUtil.ComputeSha256Hash(password);

            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            var providedPasswordHash = SecurityUtil.ComputeSha256Hash(providedPassword);

            if(hashedPassword == providedPasswordHash)
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }
    }
}
