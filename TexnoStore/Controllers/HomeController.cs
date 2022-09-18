using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
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

        public IActionResult AddSubscribe(AllProductsListViewModel viewModel)
        {
            //if (viewModel.SubscribeModel.Email != null)
            //{
            //    service.SubscribeService.Add(viewModel.SubscribeModel);
            //}
            //else
            //    ViewBag.Message = "email is required";

            AllProductsListViewModel model = new AllProductsListViewModel();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(viewModel.SubscribeModel), Encoding.UTF8, "application/json");

                using (var response =  httpClient.PostAsync("https://localhost:7169/api/Home/AddSubscribe", content).Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        model = JsonConvert.DeserializeObject<AllProductsListViewModel>(apiResponse);
                        return RedirectToAction("ForgotPasswordConfirmation");
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return RedirectToAction("Index");
        }
    }
} 
