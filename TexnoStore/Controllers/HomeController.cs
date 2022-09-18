using Microsoft.AspNetCore.Mvc;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Models;
using TexnoStoreWebCore.Mapper;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStore.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork db;
        private readonly IUnitOfWorkService service;
        public HomeController(IUnitOfWork db,IUnitOfWorkService service)
        {
            this.service = service;
            this.db = db;
        }
        public IActionResult Index()
        {
            var products = service.HomeService.AllProducts();
            
            var viewModel = new AllProductsListViewModel()
            {
                Products=products
            };

            if (viewModel.Products.Equals(0)==null)
            {
                return RedirectToAction("ProductNotFound", "Error");
            }
            return View(viewModel);
        }
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult ProductName(int productId, int typeId)
        {
            if (typeId == 1)
            {
                var laptop = db.LaptopRepository.LaptopProduct(productId);
                return RedirectToAction("LaptopProduct", "Laptop", new { id = laptop.Id });
            }
            else if (typeId == 2)
            {
                var phone = db.PhoneRepository.PhoneProduct(productId);
                return RedirectToAction("PhoneProduct", "Phone", new { id = phone.Id });
            }
            else if(typeId == 3)
            {
                var camera = db.CameraRepository.CameraProduct(productId);
                return RedirectToAction("CameraProduct", "Camera", new { id = camera.Id });
            }

            return View();
        }

        public IActionResult AddToCard(TexnoStoreWebCore.Models.ShopCartModel model)
        {
            var name = User.Identity.Name;
            var userid = db.LoginRepository.Get(User.Identity.Name);
            model.UserId = userid.Id;

            service.HomeService.AddToCard(model);

            return PartialView("Success");
        }

        public IActionResult AddSubscribe(SubscribeModel model)
        {
            if (ModelState.IsValid)
            {
                SubscribeMapper mapper = new SubscribeMapper();
                var subscribe = mapper.Map(model);
                db.SubscribeRepository.Add(subscribe);
            }
            else
                ViewBag.Message = "email is required";
            return RedirectToAction("Index");
        }
    }
}
