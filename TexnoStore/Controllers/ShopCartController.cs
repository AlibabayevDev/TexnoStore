﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Mapper;
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
            var userid = db.LoginRepository.Get(User.Identity.Name);

            var allProductsList = Checkout();
            var model = new ShopCartListViewModel()
            {
                ShopCartModels = allProductsList
            };

            
            foreach(var price in model.ShopCartModels)
            {
                model.ShopCartCount++;
                model.ShopCartPrice += price.Price*price.Count;
            }
            return PartialView(model);
        }

        

        public IActionResult Delete(int id)
        {
            db.ShopCartRepository.Delete(id);
            return RedirectToAction("ShopCartList");
        }



        public List<ShopCartModel> Checkout()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid = db.LoginRepository.Get(User.Identity.Name);

                var shopCarts = db.ShopCartRepository.GetAll(userid.Id);

                var mapper = new ShopCartMapper();
                List<ShopCartModel> ShopCarts = new List<ShopCartModel>();

                for (int i = 0; i < shopCarts.Count; i++)
                {
                    var shopCart = shopCarts[i];
                    var shopCartModel = mapper.Map(shopCart);

                    ShopCarts.Add(shopCartModel);
                }

                return ShopCarts;
            }
            else
            {
                var shopcartproducts = new AllProductsListViewModel()
                {
                    LaptopModel = new List<LaptopModel>(),
                    PhoneModel = new List<PhoneModel>()
                };
                return new List<ShopCartModel>();
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