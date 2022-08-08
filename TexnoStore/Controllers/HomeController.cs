using Microsoft.AspNetCore.Authorization;
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
    public class HomeController : Controller
    {
        private readonly IUnitOfWork db;
        public HomeController(IUnitOfWork db)
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
                LaptopModel = laptopsModels
            };
            if (viewModel.LaptopModel.Equals(0) && viewModel.PhoneModel.Equals(0))
            {
                return RedirectToAction("ProductNotFound", "Error");
            }
            viewModel.AllProductsListViewModel = Checkout();
            return View(viewModel);
        }
        public IActionResult Home()
        {
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



        public AllProductsListViewModel Checkout()
        {
            var userid = db.LoginRepository.Get(User.Identity.Name);
            var user = db.ShopCartRepository.GetAll(userid.Id);
            var laptops = db.LaptopRepository.Laptops();
            var laptopModel = LaptopsModels(laptops);
            var phones = db.PhoneRepository.Phones();
            var phonesModel = PhoneModels(phones);

            AllProductsListViewModel shopcartproducts = new AllProductsListViewModel();

            foreach (var a in user)
            {
                shopcartproducts.LaptopModel = laptopModel.Where(x => x.Id == a.LaptopId);
                shopcartproducts.PhoneModel = phonesModel.Where(x => x.Id == a.PhoneId);
            }
            return shopcartproducts;
        }
    }
}
