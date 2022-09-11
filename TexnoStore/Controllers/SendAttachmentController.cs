using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public SendAttachmentController(IUnitOfWork db, IHostingEnvironment env) 
        {
            this.db = db;
            this.env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailModel emailModel)
        {
            var clients = db.LoginRepository.Get();
            EmailHelper email = new EmailHelper();
            email.SendFile(emailModel, env, clients);
            return View();
        }


    }
}
