namespace TexnoStoreWebCore.Models
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int Telephone { get; set; }
        public string OrderNotes { get; set; }
    }
}
