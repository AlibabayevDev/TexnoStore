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
using TexnoStoreWebCore.Services.Abstract;
using TexnoStoreWebCore.Models.Laptops;

namespace TexnoStore.Controllers
{
    public class LaptopController : BaseController
    {
        private readonly IUnitOfWorkService service;
        public LaptopController(IUnitOfWorkService service)
        {
           this.service = service;
        }

        public IActionResult Index()
        {
            var laptops = service.LaptopService.Laptops();
            var model = new LaptopListViewModel
            {
                Laptops = laptops,
            };

            return View(model);
        }

        public IActionResult LaptopProduct(int id)
        {
            var laptop = service.LaptopService.LaptopProduct(id);
            var reviews = service.LaptopService.Reviews(id);
            var model = new LaptopListViewModel
            {
                Laptop = laptop,
                Reviews = reviews,
                CountReview=reviews.Count,
                MiddleStarCount = service.ReviewService.MiddleStarCount(reviews)
            };
            return View(model);
        }
    }
}
