using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Core.DataAccess.Implementation.SQL
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>, IUserRoleStore<User>
    {
        private readonly IUnitOfWork db;
        public UserStore(IUnitOfWork db)
        {
            this.db = db;
        }

        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #region IUserStore implementation

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            db.LoginRepository.Insert(user);


            return Task.FromResult(IdentityResult.Success);

        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
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

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            IList<string> roles = new List<string>
            {
                "A" , "SA"
            };
            return Task.FromResult(roles);
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
            return Task.FromResult(user.Email = normalizedName);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IUserPasswordStore implementation

        #endregion
    }
}
