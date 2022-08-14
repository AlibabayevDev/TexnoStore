using TexnoStore.Core.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Models;
using TexnoStore.Mapper.Laptops;
using TexnoStore.Models.Laptops;
using TexnoStore.Mapper;
using Microsoft.AspNetCore.Identity;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Models.Phones;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Mapper.Phones;
using TexnoStore.Core.Domain.Entities.Laptop;
using System;

namespace TexnoStore.Controllers
{
    public class LaptopController : BaseController
    {
        public static LaptopModel SelectedModel { get;set;}
        private readonly IUnitOfWork db;
        private readonly UserManager<User> userManager;
        public LaptopController(IUnitOfWork db) : base(db)
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
                Laptop = laptopModels.FirstOrDefault(x => x.Id == id),
            };
            SelectedModel = model.Laptop;
            return View("LaptopProduct",model);
        }

        public string ErrorMessage { get; set; }

        public JsonResult AddReview(ReviewModel model)
        {
            ReviewMapper reviewMapper = new ReviewMapper();

            var review = reviewMapper.Map(model);
            try
            {
                db.ReviewRepository.Add(review);
                ErrorMessage = "Succesfully added";

            }
            catch (Exception ex)
            {
                ErrorMessage = "Something went wrong";
            }
            return Json(ErrorMessage);
        }
        public IActionResult Review(LaptopListViewModel viewModel,int rating)
        {
            viewModel.Laptop = SelectedModel;

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
                return RedirectToAction("LaptopProduct", new {id=viewModel.Laptop.Id});
            }

            ReviewMapper reviewMapper = new ReviewMapper();
            viewModel.Review.Rating = rating;
            viewModel.Review.ProductId = SelectedModel.Id;

            var review = reviewMapper.Map(viewModel.Review);
            try
            {
                db.ReviewRepository.Add(review);
            }
            catch(Exception ex)
            {
                TempData["Message"] = "Something went wrong";
            }

      
            return LaptopProduct(viewModel.Laptop.Id);
        }
        public IActionResult ShopCart(LaptopListViewModel viewModel)
		{
            var name=User.Identity.Name;
            var userid = userManager.FindByNameAsync(name).Result;
            ShopCartMapper shopCartMapper = new ShopCartMapper();
            viewModel.ShopCart = new ShopCartModel();
            viewModel.ShopCart.LaptopId = viewModel.Id;
            viewModel.ShopCart.UserId = userid.Id;
            var shopCart = shopCartMapper.Map(viewModel.ShopCart);
            db.ShopCartRepository.Add(shopCart);
            viewModel.Laptop = SelectedModel;

            return View("LaptopProduct",viewModel);
        }
        public  IActionResult ShopCartbyId(int Id)
        {
            ShopCartMapper shopCartMapper = new ShopCartMapper();

            return View("LaptopProduct");
        }

        public IActionResult QuickView(int id)
        {
            var laptops = db.LaptopRepository.Laptops();

            LaptopMapper laptopMapper = new LaptopMapper();
            List<LaptopModel> laptopModels = new List<LaptopModel>();

            for (int i = 0; i < laptops.Count; i++)
            {
                var laptop = laptops[i];
                var laptopModel = laptopMapper.Map(laptop);

                laptopModels.Add(laptopModel);
            }
            var model = laptopModels.FirstOrDefault(x => x.Id == id);
            return PartialView(model);
        }
    }
}
