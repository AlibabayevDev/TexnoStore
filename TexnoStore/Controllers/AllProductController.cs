using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Mapper;
using TexnoStore.Models;
using TexnoStore.Models.Laptops;
using TexnoStore.Models.Phones;
using TexnoStoreWebCore.Mapper;
using TexnoStoreWebCore.Models;

namespace TexnoStore.Controllers
{
    public class AllProductController : Controller
    {
        private readonly IUnitOfWork db;
        public AllProductController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index(BaseModel model)
        {
            if (model.Name == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (model.ProductType == 0)
            {
                var products = db.AllProductRepository.GetAllProducts();
                var prodcutsModels = BaseModels(products).Where(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) || x.LongDesc.ToUpper().Contains(model.Name.ToUpper()) || x.ShortDesc.ToUpper().Contains(model.Name.ToUpper()));
                var viewModel = new AllProductsListViewModel()
                {
                    Products = prodcutsModels,
                };
                return View(viewModel);
            }
            else if(model.ProductType == 1)
            {
                var products = db.AllProductRepository.GetAllProducts();
                var prodcutsModels = BaseModels(products).Where(x => (x.Name.ToUpper().Contains(model.Name.ToUpper()) || x.LongDesc.ToUpper().Contains(model.Name.ToUpper()) || x.ShortDesc.ToUpper().Contains(model.Name.ToUpper())) && x.ProductType==1);
                var viewModel = new AllProductsListViewModel()
                {
                    Products = prodcutsModels,
                };
                return View(viewModel);
            }
            else if(model.ProductType == 2)
            {
                var products = db.AllProductRepository.GetAllProducts();
                var prodcutsModels = BaseModels(products).Where(x => (x.Name.ToUpper().Contains(model.Name.ToUpper()) || x.LongDesc.ToUpper().Contains(model.Name.ToUpper()) || x.ShortDesc.ToUpper().Contains(model.Name.ToUpper())) && x.ProductType == 2);
                var viewModel = new AllProductsListViewModel()
                {
                    Products = prodcutsModels,
                };
                return View(viewModel);
            }


            return View();
        }



        public List<BaseModel> BaseModels(List<BaseEntity> products)
        {
            BaseMapper baseMapper = new BaseMapper();
            List<BaseModel> productsModels = new List<BaseModel>();

            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];
                var productModel = baseMapper.Map(product);

                productsModels.Add(productModel);
            }

            return productsModels;
        }


        public JsonResult AddReview(ReviewModel model)
        {
            ReviewMapper reviewMapper = new ReviewMapper();
            string ErrorMessage;
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



    }
}
