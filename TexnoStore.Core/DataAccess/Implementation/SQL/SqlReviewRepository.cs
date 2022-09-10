using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Core.Extensions;

namespace TexnoStore.Core.DataAccess.Implementation.SQL
{
    public class SqlReviewRepository : IReviewRepository
    {
        private readonly string connectionString;

        public SqlReviewRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Add(Review review)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = "Insert into Review values(@Name,@Email,@Message,@StarCount,@LaptopId,@AddDate)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", review.Name);
                    cmd.Parameters.AddWithValue("@Email", review.Email);
                    cmd.Parameters.AddWithValue("@Message", review.Message);
                    cmd.Parameters.AddWithValue("@StarCount", review.StarCount);
                    cmd.Parameters.AddWithValue("@AddDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@LaptopId", review.ProductId);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }

        public List<Review> GetAll(int productId)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = "select * from Review where ProductId=@productId";
                using(SqlCommand cmd = new SqlCommand(cmdText,connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Review> reviews = new List<Review>();

                    while (reader.Read())
                    {
                        Review review = new Review();
                        review.Name = Convert.ToString(reader["Name"]);
                        review.Email = Convert.ToString(reader["Email"]);
                        review.Message = Convert.ToString(reader["Message"]);
                        review.StarCount = Convert.ToInt16(reader["StarCount"]);
                        review.AddDate = Convert.ToDateTime(reader["AddDate"]);
                        review.ProductId = Convert.ToInt16(reader["ProductId"]);
                        reviews.Add(review);
                    }

                    return reviews;
                }
            }
        }
    }
}
