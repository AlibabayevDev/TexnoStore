using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace EmailService.Models
{
    public class SendModel
    {
        public byte[] attachmentFileByteArray { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }
    }

}
