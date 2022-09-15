using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Services.Abstract
{
    public interface IEmailPasswordReset
    {
        bool SendEmailPasswordReset(string userEmail, string link);
    }
}
