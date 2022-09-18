using EmailService.Models;
using EmailService.Services.Abstract;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities;

namespace EmailService.Services.Implementations
{
    public class EmailAttachmentSender : IEmailAttachmentSender
    {
        public void SendAttachment(EmailModel emailModel, IHostingEnvironment env, List<User> clients)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Adminstrator", "alibabaev375@mail.ru"));
            message.Subject = "Confirm Password";
            var builder = new BodyBuilder();
            builder.Attachments.Add(env.WebRootPath + "\\texnostore.txt");
            message.Body = builder.ToMessageBody();


            for (int i = 0; i < clients.Count; i++)
            {
                message.To.Add(new MailboxAddress("naren", clients[i].Email));
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.mail.ru", 25, false);
                    client.Authenticate("alibabaev375@mail.ru", "UnhvOfx824cPnFhevo3g");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
        }


        public void SendAttachmentAsync(SendModel emailModel, IConfiguration configuration, List<User> clients)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Adminstrator", "alibabaev375@mail.ru"));
            message.Subject = "Confirm Password";
            var builder = new BodyBuilder();

            //if (emailModel.Attachments != null)
            //{
            //    byte[] attachmentFileByteArray;
            //    if (emailModel.Attachments.Length > 0)
            //    {
            //        using (MemoryStream memoryStream = new MemoryStream())
            //        {
            //            emailModel.Attachments.CopyTo(memoryStream);
            //            attachmentFileByteArray = memoryStream.ToArray();
            //        }
            //        builder.Attachments.Add(emailModel.Attachments.FileName, attachmentFileByteArray, ContentType.Parse(emailModel.Attachments.ContentType));
            //        message.Body = builder.ToMessageBody();
            //    }
            //}

            //var host = configuration["EmailSettings:Host"];
            //var port = int.Parse(configuration["EmailSettings:Port"]);
            //var sender = configuration["EmailSettings:Email"];
            //var password = configuration["EmailSettings:Password"];
            //var useSSL = bool.Parse(configuration["EmailSettings:UseSSL"]);

            for (int i = 0; i < clients.Count; i++)
            {
                message.To.Add(new MailboxAddress("naren", clients[i].Email));
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.mail.ru", 25, false);
                    client.Authenticate("alibabaev375@mail.ru", "UnhvOfx824cPnFhevo3g");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
        }
    }
}
