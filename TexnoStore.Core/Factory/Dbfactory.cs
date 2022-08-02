using TexnoStore.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Implementation.SQL;

namespace TexnoStore.Core.Factory
{
    public class DbFactory
    {
        public static IUnitOfWork Create(string connectionString)
        {
            return new SqlUnitOfWork(connectionString);
        }
    }
}
