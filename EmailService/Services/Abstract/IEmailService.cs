using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Services.Abstract
{
    public interface IEmailService
    {
        IEmailAttachmentSender AttachmentSender { get; }
        IEmailPasswordReset PasswordReset { get; }
    }
}
