using EmailService.Models;
using EmailService.Services.Abstract;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TexnoStore.Core.DataAccess.Abstract;

namespace EmailServiceWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendAttachmentController : ControllerBase
    {
        private readonly IEmailServiceSender emailService;
        private readonly IUnitOfWork db;
        private readonly IConfiguration configuration;

        public SendAttachmentController(IUnitOfWork db, IEmailServiceSender emailService, IConfiguration configuration)
        {
            this.emailService = emailService;
            this.db = db;
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult Index([FromBody] SendModel emailModel)
        {
            try 
            {
                var clients = db.LoginRepository.Get();
                emailService.AttachmentSender.SendAttachmentAsync(emailModel, configuration, clients);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong");
            }
          
        }
    }
}
