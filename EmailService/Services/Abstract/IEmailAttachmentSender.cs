using EmailService.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities;

namespace EmailService.Services.Abstract
{
    public interface IEmailAttachmentSender
    {
        void SendAttachment(EmailModel emailModel, IHostingEnvironment env, List<User> clients);

        void SendAttachmentAsync(SendModel emailModel, IConfiguration configuration, List<User> clients);

    }
}
