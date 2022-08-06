using TexnoStore.Core.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Models;
using TexnoStore.Mapper.Laptops;
using TexnoStore.Models.Laptops;
using TexnoStore.Mapper;

namespace TexnoStore.Controllers
{
    public class LaptopController : Controller
    {
        public static int test { get;set;}
        private readonly IUnitOfWork db;

        public LaptopController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var laptops = db.LaptopRepository.Laptops();

            LaptopMapper laptopMapper = new LaptopMapper();
            List<LaptopModel> laptopModels = new List<LaptopModel>();

            for(int i=0;i<laptops.Count; i++)
            {
                var laptop = laptops[i];
                var laptopModel = laptopMapper.Map(laptop);

                laptopModels.Add(laptopModel);
            }
            var model = new LaptopListViewModel
            {
                Laptops = laptopModels,
            };
            return View(model);
        }

        public IActionResult LaptopProduct(int id)
        {
            test = id;
            var laptops = db.LaptopRepository.Laptops();

            LaptopMapper laptopMapper = new LaptopMapper();
            List<LaptopModel> laptopModels = new List<LaptopModel>();

            for (int i = 0; i < laptops.Count; i++)
            {
                var laptop = laptops[i];
                var laptopModel = laptopMapper.Map(laptop);

                laptopModels.Add(laptopModel);
            }
            var model = new LaptopListViewModel
            {
                Laptop = laptopModels.FirstOrDefault(x => x.Id == id)
            };

            return View(model);
        }

        public IActionResult Korzina(LaptopModel model)
        {
            return View();
        }

        public IActionResult Review(ReviewModel reviewModel)
        {
            if (ModelState.IsValid == false)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
                var errorMessage = errors.Aggregate((message, value) =>
                {
                        if (message.Length == 0)
                            return value;

                        return message + ", " + value;
                });

                TempData["Message"] = errorMessage;
                return RedirectToAction("LaptopProduct");
            }

            ReviewMapper reviewMapper = new ReviewMapper();

            var review = reviewMapper.Map(reviewModel);
            try
            {
                db.ReviewRepository.Add(review);
            }
            catch
            {
                TempData["Message"] = "Something went wrong";
            }
            return View();      
        }

        public IActionResult ShopCart(LaptopListViewModel viewModel)
		{
            viewModel.ShopCart = new ShopCartModel();
            viewModel.ShopCart.LaptopId = test;


            ShopCartMapper shopCartMapper = new ShopCartMapper();
            var shopCart = shopCartMapper.Map(viewModel.ShopCart);
            db.ShopCartRepository.Add(shopCart);
            return View("LaptopProduct",viewModel);
        }
    }
}
