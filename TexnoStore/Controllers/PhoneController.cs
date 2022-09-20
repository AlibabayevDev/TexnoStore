using TexnoStore.Core.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Models.Phones;
using TexnoStoreWebCore.Models.Phones;
using TexnoStoreWebCore.Mapper.Phones;
using Newtonsoft.Json;
using System.Net.Http;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStoreWebCore.Models.Laptops;

namespace TexnoStore.Controllers
{
    public class PhoneController : BaseController
    {
        private readonly IUnitOfWork db;

        public PhoneController(IUnitOfWork db) 
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var phones = new List<PhoneModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync("https://localhost:7169/api/Phone/GetAll/").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        phones = JsonConvert.DeserializeObject<List<PhoneModel>>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            var model = new PhoneListViewModel
            {
                Phones = phones,
            };
            return View(model);
        }

        public IActionResult PhoneProduct(int id)
        {
            var phone = new PhoneModel();
            using(var httpClient = new HttpClient())
            {
                using(var response = httpClient.GetAsync("https://localhost:7169/api/Phone/PhoneProduct/"+id).Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    phone = JsonConvert.DeserializeObject<PhoneModel>(apiResponse);
                }
            }
            var model = new PhoneListViewModel
            {
                Phone = phone,
            };

            return View(model);
        }
    }
}
