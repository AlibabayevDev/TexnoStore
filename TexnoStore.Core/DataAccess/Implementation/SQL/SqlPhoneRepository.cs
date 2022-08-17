using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Extention;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Core.DataAccess.Implementation.SQL
{
    public class SqlPhoneRepository : IPhoneRepository
    {
        private readonly string connectionString;

        public SqlPhoneRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region CRUD

        //public bool Delete(int ID)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string cmdText = $"Delete from Clients where Id = @Id";
        //        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@ID", ID);

        //            int affectedCount = cmd.ExecuteNonQuery();

        //            return affectedCount == 1;
        //        }
        //    }
        //}


        //public bool Insert(Client client)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string cmdText = $"Insert into Clients values(@Name,@Surname,@FatherName,@FIN,@Seriya,@Phone,@Adress,@IsDeleted,@AccountNumber,@PlaceOfBirth,@Citizenship,@Studies,@Email,@PassportEndTime,@BirthDate,@Country,@City,@AccountingTime,@PassportSubmissionTime)";

        //        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@Name", client.Name);
        //            cmd.Parameters.AddWithValue("@Surname", client.Surname);
        //            cmd.Parameters.AddWithValue("@FatherName", client.FatherName);
        //            cmd.Parameters.AddWithValue("@FIN", client.FIN);
        //            cmd.Parameters.AddWithValue("@Seriya", client.Seriya);
        //            cmd.Parameters.AddWithValue("@Phone", client.Phone);
        //            cmd.Parameters.AddWithValue("@Adress", client.Adress);
        //            cmd.Parameters.AddWithValue("@IsDeleted", client.IsDeleted);
        //            cmd.Parameters.AddWithValue("@AccountNumber", client.AccountNumber);
        //            cmd.Parameters.AddWithValue("@PlaceOfBirth", client.PlaceOfBirth);
        //            cmd.Parameters.AddWithValue("@Citizenship", client.Citizenship);
        //            cmd.Parameters.AddWithValue("@Studies", client.Studies);
        //            cmd.Parameters.AddWithValue("@Email", client.Email);
        //            cmd.Parameters.AddWithValue("@PassportEndTime", client.PassportSubmissionTime);
        //            cmd.Parameters.AddWithValue("@BirthDate",client.BirthDate);
        //            cmd.Parameters.AddWithValue("@Country", client.Country); 
        //            cmd.Parameters.AddWithValue("@City", client.City);
        //            cmd.Parameters.AddWithValue("@AccountingTime",DateTime.Now);
        //            cmd.Parameters.AddWithValue("@PassportSubmissionTime", client.PassportSubmissionTime);

        //            int affectedCount = cmd.ExecuteNonQuery();

        //            return affectedCount == 1;
        //        }
        //    }
        //}


        //public List<Client> Get()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string cmdText = "select * from Clients where IsDeleted = 0";
        //        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        //        {
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            List<Client> clients = new List<Client>();

        //            while (reader.Read())
        //            {
        //                Client client = new Client();

        //                client.Id = (int)reader["Id"];
        //                client.Name = Convert.ToString(reader["Name"]);
        //                client.Surname = (string)reader["Surname"];
        //                client.FatherName = (string)reader["FatherName"];
        //                client.FIN = Convert.ToString(reader["FIN"]);
        //                client.Seriya = Convert.ToString(reader["Seriya"]);
        //                client.Phone = Convert.ToString(reader["Phone"]);
        //                client.Adress = Convert.ToString(reader["Adress"]);
        //                client.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
        //                client.AccountNumber = (int)reader["AccountNumber"];
        //                client.PlaceOfBirth = Convert.ToString(reader["PlaceOfBirth"]);
        //                client.Citizenship = Convert.ToString(reader["Citizenship"]);
        //                client.Studies = Convert.ToString(reader["Studies"]);
        //                client.Email = Convert.ToString(reader["Email"]);
        //                client.PassportEndTime = Convert.ToDateTime(reader["PassportEndTime"]);
        //                client.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
        //                client.Country = Convert.ToString(reader["Country"]);
        //                client.City = Convert.ToString(reader["City"]);
        //                client.AccountingTime = Convert.ToDateTime(reader["AccountingTime"]);
        //                client.PassportSubmissionTime = Convert.ToDateTime(reader["PassportSubmissionTime"]);

        //                clients.Add(client);
        //            }

        //            return clients;
        //        }
        //    }
        //}


        //public List<Client> GetRestore()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string cmdText = "select* from Clients where IsDeleted = 1";
        //        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        //        {
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            List<Client> clients = new List<Client>();

        //            while (reader.Read())
        //            {
        //                Client client = new Client();

        //                client.Id = (int)reader["Id"];
        //                client.Name = Convert.ToString(reader["Name"]);
        //                client.Surname = (string)reader["Surname"];
        //                client.FatherName = (string)reader["FatherName"];
        //                client.FIN = Convert.ToString(reader["FIN"]);
        //                client.Seriya = Convert.ToString(reader["Seriya"]);
        //                client.Phone = Convert.ToString(reader["Phone"]);
        //                client.Adress = Convert.ToString(reader["Adress"]);
        //                client.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
        //                client.AccountNumber = (int)reader["AccountNumber"];
        //                client.PlaceOfBirth = Convert.ToString(reader["PlaceOfBirth"]);
        //                client.Citizenship = Convert.ToString(reader["Citizenship"]);
        //                client.Studies = Convert.ToString(reader["Studies"]);
        //                client.Email = Convert.ToString(reader["Email"]);
        //                client.PassportEndTime = Convert.ToDateTime(reader["PassportEndTime"]);
        //                client.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
        //                client.Country = Convert.ToString(reader["Country"]);
        //                client.City = Convert.ToString(reader["City"]);
        //                client.PassportSubmissionTime = Convert.ToDateTime(reader["PassportSubmissionTime"]);
        //                client.AccountingTime = Convert.ToDateTime(reader["AccountingTime"]);
        //                clients.Add(client);
        //            }

        //            return clients;
        //        }
        //    }
        //}
        //public Client GetCards(int Id)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string cmdText = "select Card.Id as CardId,Card.CardNumber,Card.EndDate,Card.TypeCard,Clients.Id,Clients.Name,Clients.Surname,Clients.FatherName,Clients.FIN,Clients.Seriya,Clients.Phone,Clients.Adress,Clients.IsDeleted,Clients.AccountNumber,Clients.PlaceOfBirth,Clients.Citizenship,Clients.Studies,Clients.Email,Clients.PassportEndTime,Clients.BirthDate,Clients.Country,Clients.City,Clients.AccountingTime,Clients.PassportSubmissionTime from Clients inner join Card on Clients.Id = Card.ClientId where clients.IsDeleted = 0 AND card.IsDeleted = 0 AND Clients.Id = @Id";
        //        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        //        {
        //            cmd.Parameters.AddWithValue("Id", Id);

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            Client client = new Client();

        //            while (reader.Read())
        //            {
        //                client.CardId = (int)reader["CardId"];
        //                client.Card = new Card()
        //                {
        //                    Id = client.CardId,
        //                    CardNumber = Convert.ToString(reader["CardNumber"]),
        //                    EndDate = Convert.ToDateTime(reader["EndDate"]),
        //                    TypeCard = Convert.ToString(reader["TypeCard"]),
        //                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"]),
        //                };
        //                client.Id = (int)reader["Id"];
        //                client.Name = Convert.ToString(reader["Name"]);
        //                client.Surname = (string)reader["Surname"];
        //                client.FatherName = (string)reader["FatherName"];
        //                client.FIN = Convert.ToString(reader["FIN"]);
        //                client.Seriya = Convert.ToString(reader["Seriya"]);
        //                client.Phone = Convert.ToString(reader["Phone"]);
        //                client.Adress = Convert.ToString(reader["Adress"]);
        //                client.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
        //                client.AccountNumber = (int)reader["AccountNumber"];
        //                client.PlaceOfBirth = Convert.ToString(reader["PlaceOfBirth"]);
        //                client.Citizenship = Convert.ToString(reader["Citizenship"]);
        //                client.Studies = Convert.ToString(reader["Studies"]);
        //                client.Email = Convert.ToString(reader["Email"]);
        //                client.PassportEndTime = Convert.ToDateTime(reader["PassportEndTime"]);
        //                client.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
        //                client.Country = Convert.ToString(reader["Country"]);
        //                client.City = Convert.ToString(reader["City"]);
        //                client.AccountingTime = Convert.ToDateTime(reader["AccountingTime"]);
        //                client.PassportSubmissionTime = Convert.ToDateTime(reader["PassportSubmissionTime"]);
        //            }

        //            return client;
        //        }
        //    }
        //}
        //public List<Client> GetCard(int Id)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string cmdText = "select Card.Id as CardId,Card.CardNumber,Card.EndDate,Card.TypeCard,Card.IsDeleted,Clients.Id,Clients.Name,Clients.Surname,Clients.FatherName,Clients.FIN,Clients.Seriya,Clients.Phone,Clients.Adress,Clients.IsDeleted,Clients.AccountNumber,Clients.PlaceOfBirth,Clients.Citizenship,Clients.Studies,Clients.Email,Clients.PassportEndTime,Clients.BirthDate,Clients.Country,Clients.City,Clients.AccountingTime,Clients.PassportSubmissionTime from Clients inner join Card on Clients.Id = Card.ClientId where clients.IsDeleted = 0 AND Clients.Id = @Id";
        //        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        //        {
        //            cmd.Parameters.AddWithValue("Id", Id);

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            List<Client> clients = new List<Client>();


        //            while (reader.Read())
        //            {
        //                Client client = new Client();

        //                client.CardId = (int)reader["CardId"];
        //                client.Card = new Card()
        //                {
        //                    Id = client.CardId,
        //                    TypeCard = Convert.ToString(reader["TypeCard"]),
        //                    CardNumber = Convert.ToString(reader["CardNumber"]),
        //                    EndDate = Convert.ToDateTime(reader["EndDate"]),
        //                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"]),
        //                };
        //                client.Id = (int)reader["Id"];
        //                client.Name = Convert.ToString(reader["Name"]);
        //                client.Surname = (string)reader["Surname"];
        //                client.FatherName = (string)reader["FatherName"];
        //                client.FIN = Convert.ToString(reader["FIN"]);
        //                client.Seriya = Convert.ToString(reader["Seriya"]);
        //                client.Phone = Convert.ToString(reader["Phone"]);
        //                client.Adress = Convert.ToString(reader["Adress"]);
        //                client.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
        //                client.AccountNumber = (int)reader["AccountNumber"];
        //                client.PlaceOfBirth = Convert.ToString(reader["PlaceOfBirth"]);
        //                client.Citizenship = Convert.ToString(reader["Citizenship"]);
        //                client.Studies = Convert.ToString(reader["Studies"]);
        //                client.Email = Convert.ToString(reader["Email"]);
        //                client.PassportEndTime = Convert.ToDateTime(reader["PassportEndTime"]);
        //                client.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
        //                client.Country = Convert.ToString(reader["Country"]);
        //                client.City = Convert.ToString(reader["City"]);
        //                client.AccountingTime = Convert.ToDateTime(reader["AccountingTime"]);
        //                client.PassportSubmissionTime = Convert.ToDateTime(reader["PassportSubmissionTime"]);
        //                clients.Add(client);
        //            }


        //            return clients;
        //        }
        //    }
        //}

        //public Client GetCredit(int Id)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string cmdText = "select Credit.Id as CreditId,Credit.Amount,Credit.ReturnDate,Credit.CreditPercent,Credit.AmountReturn,Credit.GiveDate,Credit.BranchId,Clients.Id,Clients.Name,Clients.Surname,Clients.FatherName,Clients.FIN,Clients.Seriya,Clients.Phone,Clients.Adress,Clients.IsDeleted,Clients.AccountNumber,Clients.PlaceOfBirth,Clients.Citizenship,Clients.Studies,Clients.Email,Clients.PassportEndTime,Clients.BirthDate,Clients.Country,Clients.City,Clients.AccountingTime,Clients.PassportSubmissionTime from Clients inner join Credit on Clients.Id = Credit.ClientId where clients.IsDeleted = 0 AND Credit.IsDeleted = 0 AND Credit.Id = @Id";
        //        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        //        {
        //            cmd.Parameters.AddWithValue("Id", Id);

        //            SqlDataReader reader = cmd.ExecuteReader();
        //            Client client = new Client();

        //            while (reader.Read())
        //            {
        //                client.CreditId = (int)reader["CreditId"];
        //                client.Credit = new Credit()
        //                {
        //                    Id = client.CreditId,
        //                    Amount = Convert.ToDouble(reader["Amount"]),
        //                    ReturnDate = Convert.ToDateTime(reader["ReturnDate"]),
        //                    CreditPercent = Convert.ToDouble(reader["CreditPercent"]),
        //                    AmountReturn = Convert.ToDouble(reader["AmountReturn"]),
        //                    GiveDate = Convert.ToDateTime(reader["GiveDate"]),
        //                    BranchId = Convert.ToInt32(reader["BranchId"]),
        //                };
        //                client.Id = (int)reader["Id"];
        //                client.Name = Convert.ToString(reader["Name"]);
        //                client.Surname = (string)reader["Surname"];
        //                client.FatherName = (string)reader["FatherName"];
        //                client.FIN = Convert.ToString(reader["FIN"]);
        //                client.Seriya = Convert.ToString(reader["Seriya"]);
        //                client.Phone = Convert.ToString(reader["Phone"]);
        //                client.Adress = Convert.ToString(reader["Adress"]);
        //                client.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
        //                client.AccountNumber = (int)reader["AccountNumber"];
        //                client.PlaceOfBirth = Convert.ToString(reader["PlaceOfBirth"]);
        //                client.Citizenship = Convert.ToString(reader["Citizenship"]);
        //                client.Studies = Convert.ToString(reader["Studies"]);
        //                client.Email = Convert.ToString(reader["Email"]);
        //                client.PassportEndTime = Convert.ToDateTime(reader["PassportEndTime"]);
        //                client.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
        //                client.Country = Convert.ToString(reader["Country"]);
        //                client.City = Convert.ToString(reader["City"]);
        //                client.AccountingTime = Convert.ToDateTime(reader["AccountingTime"]);
        //                client.PassportSubmissionTime = Convert.ToDateTime(reader["PassportSubmissionTime"]);
        //            }

        //            return client;
        //        }
        //    }
        //}
        //public List<Client> GetCredits(int Id)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string cmdText = "select Credit.Id as CreditId,Credit.Amount,Credit.ReturnDate,Credit.CreditPercent,Credit.AmountReturn,Credit.GiveDate,Clients.Id,Clients.Name,Clients.Surname,Clients.FatherName,Clients.FIN,Clients.Seriya,Clients.Phone,Clients.Adress,Clients.IsDeleted,Clients.AccountNumber,Clients.PlaceOfBirth,Clients.Citizenship,Clients.Studies,Clients.Email,Clients.PassportEndTime,Clients.BirthDate,Clients.Country,Clients.City,Clients.AccountingTime,Clients.PassportSubmissionTime from Clients inner join Credit on Clients.Id = Credit.ClientId where clients.IsDeleted = 0 AND Credit.IsDeleted = 0 AND Clients.Id = @Id";
        //        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        //        {
        //            cmd.Parameters.AddWithValue("Id", Id);

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            List<Client> clients = new List<Client>();


        //            while (reader.Read())
        //            {
        //                Client client = new Client();

        //                client.CreditId = (int)reader["CreditId"];
        //                client.Credit = new Credit()
        //                {
        //                    Id = client.CreditId,
        //                    Amount = Convert.ToDouble(reader["Amount"]),
        //                    ReturnDate = Convert.ToDateTime(reader["ReturnDate"]),
        //                    CreditPercent = Convert.ToDouble(reader["CreditPercent"]),
        //                    AmountReturn = Convert.ToDouble(reader["AmountReturn"]),
        //                    GiveDate = Convert.ToDateTime(reader["GiveDate"]),
        //                };
        //                client.Id = (int)reader["Id"];
        //                client.Name = Convert.ToString(reader["Name"]);
        //                client.Surname = (string)reader["Surname"];
        //                client.FatherName = (string)reader["FatherName"];
        //                client.FIN = Convert.ToString(reader["FIN"]);
        //                client.Seriya = Convert.ToString(reader["Seriya"]);
        //                client.Phone = Convert.ToString(reader["Phone"]);
        //                client.Adress = Convert.ToString(reader["Adress"]);
        //                client.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
        //                client.AccountNumber = (int)reader["AccountNumber"];
        //                client.PlaceOfBirth = Convert.ToString(reader["PlaceOfBirth"]);
        //                client.Citizenship = Convert.ToString(reader["Citizenship"]);
        //                client.Studies = Convert.ToString(reader["Studies"]);
        //                client.Email = Convert.ToString(reader["Email"]);
        //                client.PassportEndTime = Convert.ToDateTime(reader["PassportEndTime"]);
        //                client.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
        //                client.Country = Convert.ToString(reader["Country"]);
        //                client.City = Convert.ToString(reader["City"]);
        //                client.AccountingTime = Convert.ToDateTime(reader["AccountingTime"]);
        //                client.PassportSubmissionTime = Convert.ToDateTime(reader["PassportSubmissionTime"]);
        //                clients.Add(client);
        //            }

        //            return clients;
        //        }
        //    }
        //}

        //public bool Update(Client client)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string cmdText = $"Update Clients set Name = @Name, Surname = @Surname, FatherName = @FatherName, FIN = @FIN, Seriya = @Seriya, Phone = @Phone, Adress = @Adress,AccountNumber=@AccountNumber,PlaceOfBirth=@PlaceOfBirth,Citizenship=@Citizenship,Studies=@Studies,Email=@Email,PassportEndTime=@PassportEndTime,BirthDate=@BirthDate,Country=@Country,City=@City, PassportSubmissionTime=@PassportSubmissionTime, IsDeleted=@IsDeleted where id = @ID";
        //        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@ID", client.Id);
        //            cmd.Parameters.AddWithValue("@Name", client.Name);
        //            cmd.Parameters.AddWithValue("@Surname", client.Surname);
        //            cmd.Parameters.AddWithValue("@FatherName", client.FatherName);
        //            cmd.Parameters.AddWithValue("@FIN", client.FIN);
        //            cmd.Parameters.AddWithValue("@Seriya", client.Seriya);
        //            cmd.Parameters.AddWithValue("@Phone", client.Phone);
        //            cmd.Parameters.AddWithValue("@Adress", client.Adress);
        //            cmd.Parameters.AddWithValue("@AccountNumber", client.AccountNumber);
        //            cmd.Parameters.AddWithValue("@PlaceOfBirth", client.PlaceOfBirth);
        //            cmd.Parameters.AddWithValue("@Citizenship", client.Citizenship);
        //            cmd.Parameters.AddWithValue("@Studies", client.Studies);
        //            cmd.Parameters.AddWithValue("@Email", client.Email);
        //            cmd.Parameters.AddWithValue("@PassportSubmissionTime", client.PassportSubmissionTime);
        //            cmd.Parameters.AddWithValue("@PassportEndTime", client.PassportSubmissionTime.AddYears(10));
        //            cmd.Parameters.AddWithValue("@BirthDate", client.BirthDate);
        //            cmd.Parameters.AddWithValue("@Country", client.Country);
        //            cmd.Parameters.AddWithValue("@City", client.City);
        //            cmd.Parameters.AddWithValue("@IsDeleted", client.IsDeleted);
        //            int affectedCount = cmd.ExecuteNonQuery();


        //            return affectedCount == 1;
        //        }
        //    }
        //}




        //public Client Get(int Id)
        //{
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "select * from Clients where Id= @Id and IsDeleted = 0";
        //        var command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("Id", Id);
        //        var reader = command.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            var bank = GetFromReader(reader);
        //            return bank;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
        //public Client GetRestore(int Id)
        //{
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "select * from Clients where Id= @Id and IsDeleted = 1";
        //        var command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("Id", Id);
        //        var reader = command.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            var bank = GetFromReader(reader);
        //            return bank;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        #endregion

        public List<Phone> Phones()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Category.CategoryName,Phone.Id, Products.Name,Products.OldPrice, Products.Price, Products.Sale ,Products.LongDesc,Phone.ImageId,Products.MainImg, Phone.CategoryId,Products.AddDate from Phone inner join Category on Phone.CategoryId = Category.Id inner join Products on Phone.ProductId=Products.Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Phone> laptops = new List<Phone>();

                    while (reader.Read())
                    {
                        Phone phone = new Phone();
                        phone.ImageId = Convert.ToInt32(reader["ImageId"]);
                        phone.Id = Convert.ToInt32(reader["Id"]);
                        phone.PhonesImages = new PhonesImages()
                        {
                            Img = Images(phone.Id)
                        };
                        phone.Name = Convert.ToString(reader["Name"]);
                        phone.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                        phone.Price = Convert.ToDouble(reader["Price"]);
                        phone.Sale = Convert.ToInt16(reader["Sale"]);
                        phone.LongDesc = Convert.ToString(reader["LongDesc"]);
                        phone.MainImg = Convert.ToString(reader["MainImg"]);
                        phone.Category = new Category()
                        {
                            CategoryName = Convert.ToString(reader["CategoryName"])
                        };
                        phone.AddDate = Convert.ToDateTime(reader["AddDate"]);

                        laptops.Add(phone);
                    }

                    return laptops;
                }
            }

        }


        public List<Phone> SearchPhones(string Name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = @"select Category.CategoryName,Phone.Id, Phone.Name,Phone.OldPrice, Phone.Price, Phone.Sale ,Phone.LongDesc,Phone.ImageId,Phone.MainImg, Phone.CategoryId , Phone.AddDate from Phone inner join Category on Phone.CategoryId = Category.Id where Phone.name Like '"+Name+"%'Order by Phone.Name";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Name", Name);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Phone> laptops = new List<Phone>();

                    while (reader.Read())
                    {
                        Phone phone = new Phone();
                        phone.ImageId = Convert.ToInt32(reader["ImageId"]);
                        phone.Id = Convert.ToInt32(reader["Id"]);
                        phone.PhonesImages = new PhonesImages()
                        {
                            Img = Images(phone.Id)
                        };
                        phone.Name = Convert.ToString(reader["Name"]);
                        phone.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                        phone.Price = Convert.ToDouble(reader["Price"]);
                        phone.Sale = Convert.ToInt16(reader["Sale"]);
                        phone.LongDesc = Convert.ToString(reader["LongDesc"]);
                        phone.MainImg = Convert.ToString(reader["MainImg"]);
                        phone.Category = new Category()
                        {
                            CategoryName = Convert.ToString(reader["CategoryName"])
                        };
                        phone.AddDate = Convert.ToDateTime(reader["AddDate"]);
                        laptops.Add(phone);
                    }

                    return laptops;
                }
            }
        }


        public List<Image> Images(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Phone.Id,PhoneImage.ImgName  from Phone " +
                    "inner join PhonesImages on Phone.id = PhonesImages.PhoneId "+
                    "inner join PhoneImage on PhonesImages.ImageId = PhoneImage.Id where PhonesImages.PhoneId = @Id ";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Image> laptops = new List<Image>();

                    while (reader.Read())
                    {
                        Image laptop = new Image();

                        laptop.ImgName = Convert.ToString(reader["ImgName"]);

                        laptops.Add(laptop);
                    }

                    return laptops;
                }
            }
        }

        private Phone GetFromReader(SqlDataReader reader)
        {
            return new Phone()
            {
                Id = reader.Get<int>("Id"),
                Name = reader.Get<string>("Name"),
                LongDesc = reader.Get<string>("LongDesc"),
                Sale = reader.Get<int>("Sale"),
                Price = reader.Get<double>("Price"),
                OldPrice = reader.Get<double>("OldPrice"),
            };
        }


    }
}
