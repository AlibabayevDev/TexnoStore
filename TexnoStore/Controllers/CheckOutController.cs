using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Mapper;
using TexnoStore.Models;
using TexnoStore.Models.Checkout;

namespace TexnoStore.Controllers
{
    public class CheckOutController : Controller
    {
        public readonly IUnitOfWork db;
        public CheckOutController(IUnitOfWork db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var userId = db.LoginRepository.Get(User.Identity.Name);

            var shopCarts = db.ShopCartRepository.GetAll(userId.Id);
            

            var mapper = new ShopCartMapper();
            List<ShopCartModel> ShopCarts = new List<ShopCartModel>();

            for (int i = 0; i < shopCarts.Count; i++)
            {
                var shopCart = shopCarts[i];
                var shopCartModel = mapper.Map(shopCart);

                ShopCarts.Add(shopCartModel);
            }

            var viewModel = new CheckoutViewModel()
            {
                ShopCart = new Models.ShopCartListViewModel()
                {
                    ShopCartModels = ShopCarts,
                }
            };
            return View(viewModel);
        }
    }
}
