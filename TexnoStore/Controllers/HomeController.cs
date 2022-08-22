using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Mapper;
using TexnoStore.Mapper.Laptops;
using TexnoStore.Mapper.Phones;
using TexnoStore.Models;
using TexnoStore.Models.Laptops;
using TexnoStore.Models.Phones;

namespace TexnoStore.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork db;
        public HomeController(IUnitOfWork db) : base(db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var laptops = db.LaptopRepository.Laptops();
            var phones = db.PhoneRepository.Phones();
            var cameras = db.CameraRepository.Cameras();

            var laptopsModels = LaptopsModels(laptops);
            var phonesModels = PhoneModels(phones);
            var cameraModels = CameraModels(cameras);

            var viewModel = new AllProductsListViewModel()
            {
                PhoneModel = phonesModels,
                LaptopModel = laptopsModels,
                CameraModel = cameraModels
            };

            if (viewModel.LaptopModel.Equals(0) && viewModel.PhoneModel.Equals(0) &&viewModel.CameraModel.Equals(0))
            {
                return RedirectToAction("ProductNotFound", "Error");
            }
            return View(viewModel);
        }
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult QuickView(int id,int type)
        {
            var product = db.AllProductRepository.QuickViewProduct(id);
            ShopCartMapper mapper = new ShopCartMapper();
            var model = mapper.Map(product);

            return PartialView(model);
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

        public IActionResult AddToCard(ShopCartModel model)
        {
            var name = User.Identity.Name;
            var userid = db.LoginRepository.Get(User.Identity.Name);

            ShopCartMapper shopCartMapper = new ShopCartMapper();
            ShopCartModel shopCartModel = new ShopCartModel();
            shopCartModel.ProductId = model.ProductId;
            shopCartModel.UserId = userid.Id;
            shopCartModel.Count = model.Count;
            var shopCart = shopCartMapper.Map(shopCartModel);
            db.ShopCartRepository.Add(shopCart);

            return PartialView("Success");
        }
    }
}
