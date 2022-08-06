using Microsoft.AspNetCore.Mvc;

namespace TexnoStore.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
