using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStoreWebCore.Mapper;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreWebCore.Services.Implementations
{
    public class ShopCartService : IShopCartService
    {
        public readonly IUnitOfWork db;
        public ShopCartService(IUnitOfWork db)
        {
            this.db = db;
        }

        public List<ShopCartModel> ShopCartList(int id)
        {
            List<ShopCartModel> shopCarts;
            if (id != 0)
            {
                shopCarts = Checkout(id);
                return shopCarts;
            }
            shopCarts = new List<ShopCartModel>();

            return shopCarts;
        }
        public double ShopCartPrice(int id)
        {
            if (id != 0)
            {
                double price = 0;
                var shopCarts = Checkout(id);

                foreach (var items in shopCarts)
                {
                    price += items.Price * items.Count;
                }
                return price;
            }
            return 0;
        }
        public List<ShopCartModel> Checkout(int id)
        {
            var shopCarts = db.ShopCartRepository.GetAll(id);

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

        public void Delete(int id)
        {
            db.ShopCartRepository.Delete(id);
        }
    }
}
