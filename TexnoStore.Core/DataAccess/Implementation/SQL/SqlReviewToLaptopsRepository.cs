using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.DataAccess.Implementation.SQL
{
    public class SqlReviewToLaptopsRepository
    {
        private readonly string connectionString;

        public SqlReviewToLaptopsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
