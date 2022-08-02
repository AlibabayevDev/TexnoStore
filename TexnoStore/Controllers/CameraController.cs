using Microsoft.AspNetCore.Mvc;

namespace TexnoStore.Controllers
{
    public class CameraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
