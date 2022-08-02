using Microsoft.AspNetCore.Mvc;

namespace TexnoStore.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ProductNotFound()
        {
            return View();
        }
    }
}
