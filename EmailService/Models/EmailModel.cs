using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace EmailService.Models
{
    public class EmailModel
    {
        public IFormFile Attachments { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }
    }

}
