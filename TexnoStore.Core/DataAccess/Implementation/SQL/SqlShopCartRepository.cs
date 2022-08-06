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
	public class SqlShopCartRepository : IShopCartRepository
	{
        private readonly string connectionString;

        public SqlShopCartRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Add(ShopCart shop)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = "Insert into ShopCart values(@UserId,@LaptopId,@PhoneId)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", shop.UserId);
                    cmd.Parameters.AddWithValue("@LaptopId", shop.LaptopId);
                    cmd.Parameters.AddWithValue("@PhoneId", shop.PhoneId);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }
    }
}
