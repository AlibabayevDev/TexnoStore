using Microsoft.AspNetCore.Mvc;

namespace TexnoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login()
        {
            
            return Ok();
        }
    }
}
