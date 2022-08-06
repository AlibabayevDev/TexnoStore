using TexnoStore.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.DataAccess.Implementation.SQL
{
    internal class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string connectionString;

        public SqlUnitOfWork(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ILaptopRepository LaptopRepository => new SqlLaptopRepository(connectionString);
        public IPhoneRepository PhoneRepository => new SqlPhoneRepository(connectionString);
        public IAllProductRepository AllProductRepository => new SqlAllProductRepository(connectionString);
        public IReviewRepository ReviewRepository => new SqlReviewRepository(connectionString);
        public ILoginRepository LoginRepository => new SqlLoginRepository(connectionString);
    }
}
