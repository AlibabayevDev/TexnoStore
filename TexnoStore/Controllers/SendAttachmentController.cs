using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Email;

namespace TexnoStore.Controllers
{
    public class SendAttachmentController : Controller
    {
        private readonly IHostingEnvironment env;
        private readonly IUnitOfWork db;
        private readonly IConfiguration configuration;
       
        public SendAttachmentController(IUnitOfWork db, IHostingEnvironment env, IConfiguration configuration) 
        {
            this.db = db;
            this.env = env;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailModel emailModel)
        {
            var clients = db.LoginRepository.Get();
            EmailFileSender email = new EmailFileSender();
            email.SendFileAsync(emailModel, configuration, clients);
            return View();
        }
    }
}
