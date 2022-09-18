using Microsoft.AspNetCore.Mvc;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStoreWebCore.Mapper;
using TexnoStoreWebCore.Models;

namespace TexnoStore.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IUnitOfWork db;
        public SubscribeController(IUnitOfWork db)
        {
            this.db = db;
        }
        public IActionResult Index(SubscribeModel model)
        {
            if (ModelState.IsValid)
            {
                SubscribeMapper mapper = new SubscribeMapper();
                var subscribe = mapper.Map(model);
                db.SubscribeRepository.Add(subscribe);
            }
            else
                ViewBag.Message = "email is required";
            return RedirectToAction(nameof(HomeController));
        }
    }
}
