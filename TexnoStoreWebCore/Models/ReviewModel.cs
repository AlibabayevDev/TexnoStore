using System.ComponentModel.DataAnnotations;

namespace TexnoStoreWebCore.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public int ProductId { get; set; }

        public int Rating { get; set; }
    }
}
