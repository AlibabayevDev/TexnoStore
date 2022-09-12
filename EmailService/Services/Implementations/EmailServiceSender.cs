using EmailService.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Services.Implementations
{
    public class EmailServiceSender : IEmailServiceSender
    {
        public IEmailAttachmentSender AttachmentSender => new EmailAttachmentSender();

        public IEmailPasswordReset PasswordReset => new EmailPasswordReset();
    }
}
