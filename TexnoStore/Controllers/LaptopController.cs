using TexnoStore.Core.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Models;
using TexnoStore.Mapper.Laptops;
using TexnoStore.Models.Laptops;

namespace TexnoStore.Controllers
{
    public class LaptopController : Controller
    {
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
                Laptops = laptopModels.Where(x => x.Id == id)
            };

            return View(model.Laptops.FirstOrDefault());
        }

        public IActionResult Korzina(LaptopModel model)
        {
            return View();
        }

    }
}
