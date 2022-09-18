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
using System.Net.Http.Json;
using System.Net.Mail;
using System.Text;
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
            byte[] attachmentFileByteArray = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7261/api/SendAttachment");

                if (emailModel.Attachments != null)
                {
                    if (emailModel.Attachments.Length > 0)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            emailModel.Attachments.CopyTo(memoryStream);
                            attachmentFileByteArray = memoryStream.ToArray();
                        }
                    }
                }
                SendModel sendModel = new SendModel();
                sendModel.attachmentFileByteArray = attachmentFileByteArray;
                sendModel.Subject=emailModel.Subject;
                sendModel.To=emailModel.To;
                var company = JsonConvert.SerializeObject(sendModel);

                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                using (var response = client.PostAsync("https://localhost:7261/api/SendAttachment", requestContent).Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    emailModel = JsonConvert.DeserializeObject<EmailModel>(apiResponse);
                }

                //var result = postTask.Result;
                //if (result.IsSuccessStatusCode)
                //{
                //    return RedirectToAction("Index");
                //}
            }

            return View();
        }
    }
}
