using TexnoStore.Core.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Models;
using TexnoStore.Models.Laptops;
using TexnoStore.Mapper;
using Microsoft.AspNetCore.Identity;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Models.Phones;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Core.Domain.Entities.Laptop;
using System;
using TexnoStoreWebCore.Services.Abstract;
using TexnoStoreWebCore.Models.Laptops;
using System.Net.Http;
using Newtonsoft.Json;

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
            List<LaptopModel> laptops = new List<LaptopModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync("http://texnostore-001-site1.etempurl.com/api/LaptopConroller/GetAll").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        laptops = JsonConvert.DeserializeObject<List<LaptopModel>>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            //var laptops = service.LaptopService.Laptops.
            var model = new LaptopListViewModel
            {
                Laptops = laptops,
            };

            return View(model);
        }

        public IActionResult LaptopProduct(int id)
        {
            LaptopModel laptop = new LaptopModel();
            //var laptop = service.LaptopService.LaptopProduct(id);
            using (var httpClient = new HttpClient())
            {
                using(var response = httpClient.GetAsync("https://localhost:7169/api/LaptopConroller/GetLaptop/" + id).Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        laptop = JsonConvert.DeserializeObject<LaptopModel>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }

            }

            var reviews = service.LaptopService.Reviews(id);
            var model = new LaptopListViewModel
            {
                Laptop = laptop,
                Reviews = reviews,
                CountReview=reviews.Count,
            };
            return View(model);
        }
    }
}
