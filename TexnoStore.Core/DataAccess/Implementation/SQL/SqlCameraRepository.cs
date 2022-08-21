using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Domain.Entities.Cameras;

namespace TexnoStore.Core.DataAccess.Implementation.SQL
{
    public class SqlCameraRepository : ICameraRepository
    {
        private readonly string connectionString;

        public SqlCameraRepository(string connectionString)
        {
            this.connectionString= connectionString;
        }


        public Camera CameraProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Category.CategoryName, Camera.Id, Camera.Company, Camera.OpticalZoom, Camera.Color, Camera.ProductId, Products.Name, Products.OldPrice, Products.TypeId, Products.Price, Products.Sale, Products.LongDesc, Camera.ImageId, Products.MainImg, Camera.CategoryId, Products.AddDate, Products.ShortDesc from Camera inner join Category on Category.Id = Camera.CategoryId inner join Products on Products.Id = Camera.ProductId where ProductId = @ProductId";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Product", productId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Camera camera = new Camera();

                    while (reader.Read())
                    {
                        camera.Id = Convert.ToInt32(reader["Id"]);
                        camera.ImageId = Convert.ToInt32(reader["ImageId"]);
                        camera.CameraImages = new CameraImages()
                        {
                            img = Images(camera.Id)
                        };
                        camera.Company = Convert.ToString(reader["Company"]);
                        camera.OpticalZoom = Convert.ToString(reader["OpticalZoom"]);
                        camera.Color = Convert.ToString(reader["Color"]);
                        camera.Name = Convert.ToString(reader["Name"]);
                        camera.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                        camera.Price = Convert.ToDouble(reader["Price"]);
                        camera.Sale = Convert.ToInt16(reader["Sale"]);
                        camera.LongDesc = Convert.ToString(reader["LongDesc"]);
                        camera.MainImg = Convert.ToString(reader["MainImg"]);
                        camera.ShortDesc = Convert.ToString(reader["ShortDesc"]);
                        camera.ProductId = Convert.ToInt16(reader["ProductId"]);
                        camera.ProductType = Convert.ToInt16(reader["TypeId"]);
                        camera.Category = new Category()
                        {
                            CategoryName = Convert.ToString(reader["CategoryName"])
                        };
                        camera.AddDate = Convert.ToDateTime(reader["AddDate"]);
                    }

                    return camera;
                }
            }
        }

        public List<Camera> Cameras()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Enum.ProductType, Camera.Id, Camera.Compaany,OpticalZoom, Camera.Color, Camera.ProductId," +
                    " Products.Name, Products.OldPrice, Products.TypeId, Products.Price, Products.Sale, Products.LongDesc, Camera.ImageId, Products.MainImg, Camera.CategoryId, Products.AddDate, Products.ShortDesc " +
                    "from Camera inner join Category on Camera.CategoryId = Category.Id inner join Products on Camera.ProductId = Product.Id inner join Enum on Enum.Id = Products.TypeId";

                using (SqlCommand cmd = new SqlCommand(cmdText))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Camera> cameras = new List<Camera>();

                    while (reader.Read())
                    {
                        Camera camera = new Camera();
                        camera.Id = Convert.ToInt32(reader["Id"]);
                        camera.ImageId = Convert.ToInt32(reader["ImageId"]);
                        camera.CameraImages = new CameraImages()
                        {
                            img = Images(camera.Id)
                        };
                        camera.Company = Convert.ToString(reader["Company"]);
                        camera.OpticalZoom = Convert.ToString(reader["OpticalZoom"]);
                        camera.Color = Convert.ToString(reader["Color"]);
                        camera.Name = Convert.ToString(reader["Name"]);
                        camera.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                        camera.Price = Convert.ToDouble(reader["Price"]);
                        camera.Sale = Convert.ToInt16(reader["Sale"]);
                        camera.LongDesc = Convert.ToString(reader["LongDesc"]);
                        camera.MainImg = Convert.ToString(reader["MainImg"]);
                        camera.ShortDesc = Convert.ToString(reader["ShortDesc"]);
                        camera.ProductId = Convert.ToInt16(reader["ProductId"]);
                        camera.ProductType = Convert.ToInt16(reader["TypeId"]);
                        camera.ProductTypeName = Convert.ToString(reader["ProductType"]);
                        camera.AddDate = Convert.ToDateTime(reader["AddDate"]);

                        cameras.Add(camera);
                    }
                     
                    return cameras;
                }
            }
        }

        public List<Image> Images(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Camera.Id, CameraImage.ImgName from Camera inner join CamerasImages on Camera.Id = CamerasImage.CameraId inner join CameraImage on CamerasImage.ImageId = CameraImage.Id where CameraImages.CameraId = @Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Image> cameras = new List<Image>();

                    while (reader.Read())
                    {
                        Image camera = new Image();

                        camera.ImgName = Convert.ToString(reader["ImgName"]);

                        cameras.Add(camera);
                    }

                    return cameras;
                }              
            }
        }

        public List<Camera> SearchCamera(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Category.CategoryName, Camera.Id, Camera.Compaany,OpticalZoom, Camera.Color, Camera.ProductId, Camera.CategoryId from Camera inner join Category on Camera.CategoryId = Category.Id where Camera.Company Like'%" + @name + "%' Order By Camera.Company";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Camera> laptops = new List<Camera>();

                    while (reader.Read())
                    {
                        Camera camera = new Camera();
                        camera.ImageId = Convert.ToInt32(reader["ImageId"]);
                        camera.Id = Convert.ToInt32(reader["Id"]);
                        camera.CameraImages = new CameraImages()
                        {
                            img = Images(camera.Id)
                        };
                        camera.Name = Convert.ToString(reader["Name"]);
                        camera.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                        camera.Price = Convert.ToDouble(reader["Price"]);
                        camera.Sale = Convert.ToInt16(reader["Sale"]);
                        camera.LongDesc = Convert.ToString(reader["LongDesc"]);
                        camera.MainImg = Convert.ToString(reader["MainImg"]);
                        camera.Category = new Category()
                        {
                            CategoryName = Convert.ToString(reader["CategoryName"])
                        };
                        camera.AddDate = Convert.ToDateTime(reader["AddDate"]);
                        laptops.Add(camera);
                    }

                    return laptops;
                }
            }
        }
    }
}
