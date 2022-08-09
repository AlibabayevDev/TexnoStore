using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Core.DataAccess.Abstract
{
    public interface ILoginRepository : ICrudRepository<User>
    {
        User Get(string username);
        User GetByLogin(string providerkey);
        bool AddKey(string providerKey);
    }
}
