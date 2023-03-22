using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStore.Models;
using TexnoStoreWebCore.Mapper;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Models.Laptops;
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
            var products = new List<BaseModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync("https://localhost:7169/api/Home/GetAllProducts").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        products = JsonConvert.DeserializeObject<List<BaseModel>> (apiResponse);
                    }
                }

            }
            var viewModel = new AllProductsListViewModel()
            {
                Products=products,
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
                return RedirectToAction("LaptopProduct", "Laptop", new { id = productId });
            }
            else if (typeId == 2)
            {
                return RedirectToAction("PhoneProduct", "Phone", new { id = productId });
            }
            else if(typeId == 3)
            { 
                return RedirectToAction("CameraProduct", "Camera", new { id = productId });
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
