using Microsoft.AspNetCore.Authorization;
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
                var laptop = service.LaptopService.LaptopProduct(productId);
                return RedirectToAction("LaptopProduct", "Laptop", new { id = laptop.Id });
            }
            else if (typeId == 2)
            {
                var phone = service.PhoneService.PhoneProduct(productId);
                return RedirectToAction("PhoneProduct", "Phone", new { id = phone.Id });
            }
            else if(typeId == 3)
            {
                var camera = service.CameraService.CameraById(productId);
                return RedirectToAction("CameraProduct", "Camera", new { id = camera.Id });
            }

            return View();
        }
        public IActionResult QuickView(int id, int type)
        {
            var model = service.AllProductService.QuickViewProduct(id);

            return PartialView(model);
        }

        public IActionResult AddToCard(TexnoStoreWebCore.Models.ShopCartModel model)
        {
            if(User.Identity.IsAuthenticated)
            {
                var name = User.Identity.Name;
                var userid = db.LoginRepository.Get(User.Identity.Name);
                model.UserId = userid.Id;

                service.HomeService.AddToCard(model);

                return PartialView("Success");
            }
            return Json(false);
        }
    }
}
