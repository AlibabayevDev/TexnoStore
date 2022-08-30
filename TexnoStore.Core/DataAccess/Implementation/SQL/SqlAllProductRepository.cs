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
    public class SqlAllProductRepository : IAllProductRepository
    {
        private readonly string connectionString;

        public SqlAllProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public BaseEntity AllProducts(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Id,Name,TypeId,MainImg,Price,LongDesc,AddDate,TypeId,OldPrice,Sale,ShortDesc from Products where @Id=Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    BaseEntity product = new BaseEntity();

                    while (reader.Read())
                    {
                        product.Id = Convert.ToInt32(reader["Id"]);
                        product.Name = Convert.ToString(reader["Name"]);
                        product.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                        product.Price = Convert.ToDouble(reader["Price"]);
                        product.Sale = Convert.ToInt16(reader["Sale"]);
                        product.LongDesc = Convert.ToString(reader["LongDesc"]);
                        product.MainImg = Convert.ToString(reader["MainImg"]);
                        product.ProductType = Convert.ToInt16(reader["TypeId"]);
                        product.ShortDesc = Convert.ToString(reader["ShortDesc"]);
                        product.AddDate = Convert.ToDateTime(reader["AddDate"]);

                    }

                    return product;
                }
            }
        }

        public List<BaseEntity> GetAllProducts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Id,Name,TypeId,MainImg,Price,LongDesc,AddDate,TypeId,OldPrice,Sale,ShortDesc,TypeId from Products";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<BaseEntity> products = new List<BaseEntity>();


                    while (reader.Read())
                    {
                        BaseEntity product = new BaseEntity();

                        product.ProductId = Convert.ToInt32(reader["Id"]);
                        product.Name = Convert.ToString(reader["Name"]);
                        product.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                        product.Price = Convert.ToDouble(reader["Price"]);
                        product.Sale = Convert.ToInt16(reader["Sale"]);
                        product.LongDesc = Convert.ToString(reader["LongDesc"]);
                        product.MainImg = Convert.ToString(reader["MainImg"]);
                        product.ProductType = Convert.ToInt16(reader["TypeId"]);
                        product.ShortDesc = Convert.ToString(reader["ShortDesc"]);
                        product.AddDate = Convert.ToDateTime(reader["AddDate"]);
                        product.ProductType = Convert.ToInt16(reader["TypeId"]);
                        products.Add(product);
                    }

                    return products;
                }
            }
        }

        public ShopCart QuickViewProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Id,Name,TypeId,MainImg,Price,LongDesc,AddDate,TypeId,OldPrice,Sale,ShortDesc from Products where @Id=Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    ShopCart product = new ShopCart();

                    while (reader.Read())
                    {
                        product.Id = Convert.ToInt32(reader["Id"]);
                        product.Name = Convert.ToString(reader["Name"]);
                        product.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                        product.Price = Convert.ToDouble(reader["Price"]);
                        product.Sale = Convert.ToInt16(reader["Sale"]);
                        product.LongDesc = Convert.ToString(reader["LongDesc"]);
                        product.MainImg = Convert.ToString(reader["MainImg"]);
                        product.ProductType = Convert.ToInt16(reader["TypeId"]);
                        product.ShortDesc = Convert.ToString(reader["ShortDesc"]);
                        product.AddDate = Convert.ToDateTime(reader["AddDate"]);
                    }

                    return product;
                }
            }
        }

        public bool Add(Review review)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = "Insert into Review values(@Name,@Email,@Message,@StarCount,@ProductId)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", review.Name);
                    cmd.Parameters.AddWithValue("@Email", review.Email);
                    cmd.Parameters.AddWithValue("@Message", review.Message);
                    cmd.Parameters.AddWithValue("@StarCount", review.StarCount);
                    cmd.Parameters.AddWithValue("@ProductId", review.ProductId);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }
    }
}
