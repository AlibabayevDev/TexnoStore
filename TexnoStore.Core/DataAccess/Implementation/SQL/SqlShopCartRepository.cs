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

                string cmdText = "Insert into ShopCarts values(@LaptopId,@PhoneId,@UserId)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@LaptopId", shop.LaptopId);
                    cmd.Parameters.AddWithValue("@PhoneId", shop.PhoneId);
                    cmd.Parameters.AddWithValue("@UserId", shop.UserId);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }
        
        public List<ShopCart> GetAll(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select * from ShopCarts where userId=@userId";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ShopCart> shopcarts = new List<ShopCart>();

                    while (reader.Read())
                    {
                        ShopCart shopCart = new ShopCart();
                        shopCart.UserId = Convert.ToInt16(reader["UserId"]);
                        shopCart.PhoneId = Convert.ToInt16(reader["PhoneId"]);
                        shopCart.LaptopId = Convert.ToInt16(reader["LaptopId"]);
                        shopcarts.Add(shopCart);
                    }

                    return shopcarts;
                }
            }
        }

    }
}
