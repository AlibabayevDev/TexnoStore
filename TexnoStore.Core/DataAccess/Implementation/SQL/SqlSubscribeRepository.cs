using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Core.DataAccess.Implementation.SQL
{
    public class SqlSubscribeRepository : ISubscribeRepository
    {
        private readonly string connectionString;
        public SqlSubscribeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Add(Subscribe subscribe)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = "Insert into Subscribe values(@Email)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", subscribe.Email);
                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }
    }
}
