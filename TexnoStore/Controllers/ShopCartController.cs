using Microsoft.AspNetCore.Mvc;

namespace TexnoStore.Controllers
{
    public class ShopCartController : Controller
    {
        [HttpPost]
        public JsonResult MeesageHandler(string data)
        {
            var result = "Сообщение " + data + "принято";
            return Json(result);
        }
    }
}
