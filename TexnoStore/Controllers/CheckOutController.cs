using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Mapper;
using TexnoStore.Models;
using TexnoStore.Models.Checkout;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStore.Controllers
{
    public class CheckOutController : Controller
    {
        public readonly IUnitOfWork db;
        public readonly IUnitOfWorkService service;

        public CheckOutController(IUnitOfWork db,IUnitOfWorkService service)
        {
            this.service = service;
            this.db = db;
        }
        public IActionResult Index()
        {
            var user = db.LoginRepository.Get(User.Identity.Name);

            var viewModel = new CheckoutViewModel()
            {
                ShopCart = new Models.ShopCartListViewModel()
                {
                    ShopCartModels = service.CheckOutService.CheckOutProducts(user.Id),
                    ShopCartPrice = service.ShopCartService.ShopCartPrice(user.Id)
                },
                
            };
            return View(viewModel);
        }

        public IActionResult Order(CheckoutViewModel viewModel)
        {
            var user = db.LoginRepository.Get(User.Identity.Name);

            service.CheckOutService.Order(user.Id, viewModel.OrderDetails);
            /*var userId = db.LoginRepository.Get(User.Identity.Name);
            var shopCarts = db.ShopCartRepository.GetAll(userId.Id);

            var mapper = new ShopCartMapper();
            List<ShopCartModel> ShopCarts = new List<ShopCartModel>();

            for (int i = 0; i < shopCarts.Count; i++)
            {
                var shopCart = shopCarts[i];
                var shopCartModel = mapper.Map(shopCart);

                ShopCarts.Add(shopCartModel);
            }
            viewModel.ShopCart.ShopCartModels = ShopCarts;

            var checkOutMapper = new CheckOutMapper();
            var orderDetails = checkOutMapper.Map(viewModel.OrderDetails);

            db.CheckOutRepository.Insert(orderDetails);
            foreach(var item in shopCarts)
            {
                db.CheckOutRepository.InsertOrderProducts(item.Id);
            }*/
            return View();
        }
    }
}
