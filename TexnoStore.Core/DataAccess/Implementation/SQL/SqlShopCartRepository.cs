using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Domain.Entities.Laptop;

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

                string cmdText = "Insert into ShopCarts values(@UserId,@ProductId,@Count)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", shop.ProductId);
                    cmd.Parameters.AddWithValue("@UserId", shop.UserId);
                    cmd.Parameters.AddWithValue("@Count", shop.Count);
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
                string cmdText = "select ShopCarts.Id,ShopCarts.UserId,ShopCarts.ProductId,ShopCarts.Count,Products.Name,Products.MainImg,Products.AddDate,Products.Price,Products.OldPrice,Products.Sale,Products.TypeId,Products.LongDesc,Products.ShortDesc from ShopCarts inner join Products on Products.Id = ShopCarts.ProductId where userId=7";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ShopCart> shopcarts = new List<ShopCart>();

                    while (reader.Read())
                    {
                        ShopCart shopCart = new ShopCart();
                        shopCart.Id = Convert.ToInt16(reader["Id"]);
                        shopCart.UserId = Convert.ToInt16(reader["UserId"]);
                        shopCart.ProductId = Convert.ToInt16(reader["ProductId"]);
                        shopCart.Count = Convert.ToInt16(reader["Count"]);
                        shopCart.Name = Convert.ToString(reader["Name"]);
                        shopCart.MainImg = Convert.ToString(reader["MainImg"]);
                        shopCart.AddDate = Convert.ToDateTime(reader["AddDate"]);
                        shopCart.Price = Convert.ToDouble(reader["Price"]);
                        shopCart.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                        shopCart.LongDesc = Convert.ToString(reader["LongDesc"]);
                        shopCart.ShortDesc = Convert.ToString(reader["ShortDesc"]);
                        shopCart.Sale = Convert.ToInt16(reader["Sale"]);
                        shopCart.ProductType=Convert.ToInt16(reader["TypeId"]);
                        shopcarts.Add(shopCart);
                    }

                    return shopcarts;
                }
            }
        }

        public bool Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Delete from ShopCarts where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", Id);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }

    }
}
