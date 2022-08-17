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

    }
}
