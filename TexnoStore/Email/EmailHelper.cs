using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using TexnoStore.Core.Domain.Entities;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace TexnoStore.Email
{
    public class EmailHelper
    {
        //public bool SendEmail(string userEmail, string confirmationLink)
        //{
        //    MailMessage mailMessage = new MailMessage();
        //    mailMessage.From = new MailAddress("nahidmir101@gmail.com");
        //    mailMessage.To.Add(new MailAddress(userEmail));

        //    mailMessage.Subject = "Confirm your email";
        //    mailMessage.IsBodyHtml = true;
        //    mailMessage.Body = confirmationLink;

        //    SmtpClient client = new SmtpClient();
        //    client.Credentials = new System.Net.NetworkCredential("info@rainpuddleslabradoodles.com", "Mydoodles!");
        //    client.Host = "smtpout.secureserver.net";
        //    client.Port = 80;

        //    try
        //    {
        //        client.Send(mailMessage);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // log exception
        //    }
        //    return false;
        //}

        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress("nahidmir101@gmail.com");
            //mailMessage.To.Add(new MailAddress(userEmail));

            //mailMessage.Subject = "Password Reset";
            //mailMessage.IsBodyHtml = true;
            //mailMessage.Body = link;

            //SmtpClient client = new SmtpClient()
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new System.Net.NetworkCredential()
            //    {
            //        UserName = "nahidmir101@gmail.com",
            //        Password = "euzbnbiytebfiomw"
            //    }
            //};


            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Adminstrator", "alibabaev375@mail.ru"));
                message.To.Add(new MailboxAddress("naren", userEmail));
                message.Subject = "Confirm Password";
    
                message.Body = new TextPart("plain")
                {
                    Text = link
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.mail.ru", 25, false);
                    client.Authenticate("alibabaev375@mail.ru", "UnhvOfx824cPnFhevo3g");
                    client.Send(message);
                    client.Disconnect(true);
                }

                return true;
            }
            catch
            {
                return false;
            }
            







            //client.Credentials = new System.Net.NetworkCredential(userEmail, "euzbnbiytebfiomw");
            //client.Host = "smtp.gmail.com";
            //client.Port = 587;

        }

        //public bool SendEmailTwoFactorCode(string userEmail, string code)
        //{
        //    MailMessage mailMessage = new MailMessage();
        //    mailMessage.From = new MailAddress("care@yogihosting.com");
        //    mailMessage.To.Add(new MailAddress(userEmail));

        //    mailMessage.Subject = "Two Factor Code";
        //    mailMessage.IsBodyHtml = true;
        //    mailMessage.Body = code;

        //    SmtpClient client = new SmtpClient();
        //    client.Credentials = new System.Net.NetworkCredential("info@rainpuddleslabradoodles.com", "Mydoodles!");
        //    client.Host = "smtpout.secureserver.net";
        //    client.Port = 80;

        //    try
        //    {
        //        client.Send(mailMessage);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // log exception
        //    }
        //    return false;
        //}

        public void SendFile(EmailModel emailModel,IHostingEnvironment env,List<User> clients)
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
    }
}
