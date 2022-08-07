using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Mapper.Laptops;
using TexnoStore.Mapper.Phones;
using TexnoStore.Models;
using TexnoStore.Models.Laptops;
using TexnoStore.Models.Phones;

namespace TexnoStore.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IUnitOfWork db;
        private readonly UserManager<User> userManager;
        public ShopCartController(IUnitOfWork db, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public IActionResult Index()
        {
            var userid = userManager.FindByNameAsync(User.Identity.Name).Result;
            var user = db.ShopCartRepository.GetAll(userid.Id);
            var laptops = db.LaptopRepository.Laptops();
            var laptopModel = LaptopsModels(laptops);
            var phones=db.PhoneRepository.Phones();
            var phonesModel=PhoneModels(phones);

            AllProductsListViewModel shopcartproducts= new AllProductsListViewModel();

            foreach(var a in user)
            {
                shopcartproducts.LaptopModel = laptopModel.Where(x => x.Id == a.LaptopId);
                shopcartproducts.PhoneModel = phonesModel.Where(x => x.Id == a.PhoneId);
            }

            return View("");
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
