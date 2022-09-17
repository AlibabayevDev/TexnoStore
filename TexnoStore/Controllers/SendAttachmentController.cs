using EmailService.Models;
using EmailService.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;


namespace TexnoStore.Controllers
{
    public class SendAttachmentController : Controller
    {
        private readonly IHostingEnvironment env;
        private readonly IUnitOfWork db;
        private readonly IConfiguration configuration;
        private readonly IEmailServiceSender emailService;
        string Baseurl = "https://localhost:7261/api/SendAttachment/";
        public SendAttachmentController(IUnitOfWork db, IEmailServiceSender emailService, IHostingEnvironment env, IConfiguration configuration)
        {
            this.db = db;
            this.env = env;
            this.configuration = configuration;
            this.emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailModel emailModel)
        {
            var users = db.LoginRepository.Get();
            emailService.AttachmentSender.SendAttachmentAsync(emailModel,configuration,users);
            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = httpClient.GetAsync("https://localhost:7261/api/SendAttachment").Result)
            //    {
            //        string apiResponse =  response.Content.ReadAsStringAsync().Result;
            //        emailModel = JsonConvert.DeserializeObject<EmailModel>(apiResponse);
            //    }
            //}

            return View();
        }
    }
}
