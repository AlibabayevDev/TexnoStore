using Microsoft.AspNetCore.Mvc;

namespace EmailServiceWebApi.Controllers
{
    public class PasswordReset : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
