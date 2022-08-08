using System.ComponentModel.DataAnnotations;

namespace TexnoStore.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public string rating { get; set; }
        public string StarCount { get; set; }

        public int LaptopId { get; set; }
    }
}
