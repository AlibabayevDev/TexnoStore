using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Core.IdentityServer
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>, IUserRoleStore<User>,IPasswordValidator<User>,IUserLoginStore<User>, IUserEmailStore<User>, IUserTwoFactorTokenProvider<User>
    {
        private readonly IUnitOfWork db;
        public UserStore(IUnitOfWork db)
        {
            this.db = db;
        }

        #region ImplementationMethods
        public void Dispose()
        {

        }
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(userId);

            User user = db.LoginRepository.Get(id);

            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = db.LoginRepository.Get(normalizedUserName);

            return Task.FromResult(user);
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }
        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }
        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }
        #endregion

        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            db.LoginRepository.Insert(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }



        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            IList<string> roles = new List<string>
            {
                "A","SA"
            } as IList<string>;

            return Task.FromResult(roles);
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Email = normalizedName;
            return Task.FromResult(user);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(user);
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            db.LoginRepository.Update(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public string HashPassword(User user, string password)
        {
            throw new NotImplementedException();
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var user = db.LoginRepository.Get(normalizedEmail);

            return Task.FromResult(user);
        }

        public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.Email = normalizedEmail;
            return Task.FromResult(user);
        }

        public Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            if (user != null)
            {
                try
                {
                    db.LoginRepository.Insert(user);
                    return Task.FromResult(user);
                }
                catch
                {
                    CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                    cancellationToken = cancelTokenSource.Token;

                    Task task = new Task(() =>
                    {
                          if (cancellationToken.IsCancellationRequested)  
                              return;     

                            Thread.Sleep(200);
                    }, cancellationToken);
                    task.Start();

                    Thread.Sleep(1000);
                    cancelTokenSource.Cancel();  
                    Thread.Sleep(1000);
      
                    cancelTokenSource.Dispose(); 
                }
            }
   
            return Task.FromResult(user);
        }

        public Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            var user = db.LoginRepository.GetByLogin(providerKey);

            return Task.FromResult(user);
        }

        public Task<string> GenerateAsync(string purpose, UserManager<User> manager, User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<User> manager, User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<User> manager, User user)
        {
            throw new NotImplementedException();
        }
    }
}