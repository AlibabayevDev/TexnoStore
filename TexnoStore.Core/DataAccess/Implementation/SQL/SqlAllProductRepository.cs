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

        public List<BaseEntity> AllProducts(string Name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select id,Name,CategoryId from Laptop where name=@Name union all select id,Name,CategoryId from Phone where name=Name";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Name", Name);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<BaseEntity> products = new List<BaseEntity>();

                    while (reader.Read())
                    {
                        BaseEntity product = new BaseEntity();
                        product.Id = Convert.ToInt32(reader["Id"]);
                        product.Name = Convert.ToString(reader["Name"]);
                        product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                        products.Add(product);
                    }

                    return products;
                }
            }
        }
    }
}
