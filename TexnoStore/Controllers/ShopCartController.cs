using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Mapper;
using TexnoStore.Models;
using TexnoStore.Models.Laptops;
using TexnoStore.Models.Phones;
using TexnoStoreWebCore.Mapper;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Models.Laptops;
using TexnoStoreWebCore.Models.Phones;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStore.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IUnitOfWork db;
        private readonly IUnitOfWorkService service;
        public ShopCartController(IUnitOfWork db,IUnitOfWorkService service)
        {
            this.service = service;
            this.db = db;
        }
        public IActionResult ShopCartList()
        {
            if(User.Identity.IsAuthenticated)
            {
                var user = db.LoginRepository.Get(User.Identity.Name);

                var allProductsList = service.ShopCartService.ShopCartList(user.Id);
                var model = new ShopCartListViewModel()
                {
                    ShopCartModels = allProductsList,
                    
                    ShopCartCount = allProductsList.Count,
                    ShopCartPrice = service.ShopCartService.ShopCartPrice(user.Id),
                };

                return PartialView(model);
            }
            var emptyModel = new ShopCartListViewModel()
            {
                ShopCartModels = new List<ShopCartModel>()
            };
            return PartialView(emptyModel);
        }

        public IActionResult ShopCartCount()
        {
            var allProductsList = Checkout();
            return Json(allProductsList.Count);
        }


        public IActionResult Delete(int id)
        {
            service.ShopCartService.Delete(id);
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
    }
}
