using Microsoft.AspNetCore.Mvc;
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
    public class AllProductController : Controller
    {
        private readonly IUnitOfWork db;

        public AllProductController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index(BaseEntity model)
        {
            if (model.Name == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (model.CategoryId == 0)
            {
                var laptops = db.LaptopRepository.Laptops();
                var phones=db.PhoneRepository.Phones();

                var laptopsModels = LaptopsModels(laptops).Where(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) || x.Name.ToUpper().Contains(model.Name.ToUpper()));
                var phonesModels = PhoneModels(phones).Where(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) || x.Name.ToUpper().Contains(model.Name.ToUpper())); 

                var viewModel = new AllProductsListViewModel()
                {
                    PhoneModel = phonesModels,
                    LaptopModel = laptopsModels
                };
                if(viewModel.LaptopModel.Equals(0)  && viewModel.PhoneModel.Equals(0))
                {
                    return RedirectToAction("ProductNotFound", "Error");
                }
                return View(viewModel);

            }
            else if(model.CategoryId == 1)
            {
                var laptops = db.LaptopRepository.Laptops();
                var laptopsModels = LaptopsModels(laptops).Where(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) || x.Name.ToUpper().Contains(model.Name.ToUpper()));

                var viewModel = new AllProductsListViewModel()
                {
                    PhoneModel = new List<PhoneModel>(),
                    LaptopModel = laptopsModels
                };

                return View(viewModel);
            }
            else if(model.CategoryId == 2)
            {
                var phones = db.PhoneRepository.Phones();

                var phonesModels = PhoneModels(phones).Where(x => x.Name.ToUpper().Contains(model.Name.ToUpper()) || x.Name.ToUpper().Contains(model.Name.ToUpper()));
                var viewModel = new AllProductsListViewModel()
                {
                    PhoneModel = phonesModels,
                    LaptopModel = new List<LaptopModel>()
                };

                return View(viewModel);
            }


            return View();
        }


        public List<LaptopModel> LaptopsModels(List<Laptop> laptops)
        {
            LaptopMapper laptopMapper = new LaptopMapper();
            List<LaptopModel> laptopsModels = new List<LaptopModel>();

            for (int i = 0; i < laptops.Count; i++)
            {
                var laptop = laptops[i];
                var laptopModel = laptopMapper.Map(laptop);

                laptopsModels.Add(laptopModel);
            }

            return laptopsModels;
        }
        public List<PhoneModel> PhoneModels(List<Phone> phones)
        {
            PhoneMapper phoneMapper = new PhoneMapper();
            List<PhoneModel> phonesModels = new List<PhoneModel>();

            for (int i = 0; i < phones.Count; i++)
            {
                var phone = phones[i];
                var phoneModel = phoneMapper.Map(phone);

                phonesModels.Add(phoneModel);
            }

            return phonesModels;
        }
    }
}
