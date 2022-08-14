using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStore.Core.Domain.Entities.Phone;
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

            var laptopsModels = LaptopsModels(laptops);
            var phonesModels = PhoneModels(phones);

            var viewModel = new AllProductsListViewModel()
            {
                PhoneModel = phonesModels,
                LaptopModel = laptopsModels,
            };
            if (viewModel.LaptopModel.Equals(0) && viewModel.PhoneModel.Equals(0))
            {
                return RedirectToAction("ProductNotFound", "Error");
            }
            return View(viewModel);
        }
        public IActionResult Home()
        {
            return View();
        }
    }
}
