using Microsoft.AspNetCore.Mvc;

namespace TexnoStoreApi.Controllers
{
    public class AccountController : ControllerBase
    {
        [Route("api/controller")]

        public IActionResult Login()
        {
            
            return Ok();
        }
    }
}
