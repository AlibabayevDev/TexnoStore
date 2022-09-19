using EmailService.Services.Abstract;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Services.Implementations
{
    public class EmailPasswordReset : IEmailPasswordReset
    {
        public bool SendEmailPasswordReset(string userEmail, string link)
        {
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

        }
    }
}
