using EmailService.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using TexnoStore.Core.DataAccess.Abstract;

namespace EmailServiceWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailPasswordController : ControllerBase
    {
        private readonly IEmailServiceSender emailService;
        private readonly IUnitOfWork db;

        public EmailPasswordController(IEmailServiceSender emailService, IUnitOfWork db)
        {
            this.db = db;
            this.emailService = emailService;
        }

        [HttpPost] 
        [Route("PasswordReset?{email}:{link}")]
        public IActionResult Index(string email,string link)
        {
            try
            {
                emailService.PasswordReset.SendEmailPasswordReset(email, link);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
          
        }
    }
}
