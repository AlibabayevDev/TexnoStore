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
    public class SqlCheckOutRepository : ICheckOutRepository
    {
        private readonly string connectionString;
        public SqlCheckOutRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Insert(OrderDetails model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Insert into OrderData values(@Name, @LastName, @Email, @Address,@City,@Country,@ZipCode,@Telephone,@OrderNotes)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("Address", model.Adress);
                    cmd.Parameters.AddWithValue("City", model.City);
                    cmd.Parameters.AddWithValue("Country", model.Country);
                    cmd.Parameters.AddWithValue("ZipCode", model.ZipCode);
                    cmd.Parameters.AddWithValue("@Telephone", model.Telephone);
                    cmd.Parameters.AddWithValue("@OrderNotes", model.OrderNotes);
                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }

        public bool InsertOrderProducts(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"insert into orderProduct values((SELECT MAX([ID]) FROM OrderData),@ShopCartId)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@ShopCartId", id);

                    
                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }
    }
}
