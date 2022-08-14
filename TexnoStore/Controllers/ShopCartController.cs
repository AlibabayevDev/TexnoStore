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
    public class ShopCartController : Controller
    {
        private readonly IUnitOfWork db;
        public ShopCartController(IUnitOfWork db)
        {
            this.db = db;
        }
        public IActionResult ShopCartList()
        {
            var allProductsList = Checkout();
            return PartialView(allProductsList);
        }




        public AllProductsListViewModel Checkout()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid = db.LoginRepository.Get(User.Identity.Name);
                var user = db.ShopCartRepository.GetAll(userid.Id);
                var laptops = db.LaptopRepository.Laptops();
                var laptopModel = LaptopsModels(laptops);
                var phones = db.PhoneRepository.Phones();
                var phonesModel = PhoneModels(phones);

                AllProductsListViewModel shopcartproducts = new AllProductsListViewModel();

                var laptoplist = new List<LaptopModel>();
                var phonelist = new List<PhoneModel>();

                foreach (var a in user)
                {
                    laptoplist.Add(laptopModel.FirstOrDefault(x => x.Id == a.LaptopId));
                    phonelist.Add(phonesModel.FirstOrDefault(x => x.Id == a.PhoneId));
                }
                shopcartproducts.LaptopModel = laptoplist;
                shopcartproducts.PhoneModel = phonelist;
                return shopcartproducts;
            }
            else
            {
                var shopcartproducts = new AllProductsListViewModel()
                {
                    LaptopModel = new List<LaptopModel>(),
                    PhoneModel = new List<PhoneModel>()
                };
                return shopcartproducts;
            }

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
