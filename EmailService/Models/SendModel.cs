using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Net.Mail;
using System.Net.Mime;

namespace EmailService.Models
{
    public class SendModel
    {
        public byte[] attachmentFileByteArray { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
    }

}
