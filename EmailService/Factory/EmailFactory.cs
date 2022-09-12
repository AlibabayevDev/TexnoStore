using EmailService.Services.Abstract;
using EmailService.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Factory
{
    public static class EmailFactory
    {
        public static IEmailService Create()
        {
            return new EmailServiceSender();
        }
    }
}
