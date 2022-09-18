using EmailService.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using TexnoStore.Core.DataAccess.Abstract;

namespace EmailServiceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("ForgotPassword")]
        public IActionResult Index(List<string> values)
        {
            try
            {
                emailService.PasswordReset.SendEmailPasswordReset(values[0], values[1]);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
          
        }
    }
}
