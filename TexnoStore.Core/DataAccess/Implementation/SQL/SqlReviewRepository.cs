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
    public class SqlReviewRepository : IReviewRepository
    {
        private readonly string connectionString;

        public SqlReviewRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public  bool Add(Review review)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = "Insert into Review values(@Name,@Email,@Message,@StarCount,@LaptopId)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", review.Name);
                    cmd.Parameters.AddWithValue("@Email", review.Email);
                    cmd.Parameters.AddWithValue("@Message", review.Message);
                    cmd.Parameters.AddWithValue("@StarCount", review.StarCount);
                    cmd.Parameters.AddWithValue("@LaptopId", review.ProductId);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }
    }
}
