using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStoreWebCore.Mapper;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreWebCore.Services.Implementations
{
    public class CheckOutService : ICheckOutService
    {
        private readonly IUnitOfWork db;
        public CheckOutService(IUnitOfWork db)
        {
            this.db = db;
        }

        public List<ShopCartModel> CheckOutProducts(int id)
        {
            var shopCarts = db.ShopCartRepository.GetAll(id);
            double shopCartPrice = 0;

            var mapper = new ShopCartMapper();
            List<ShopCartModel> ShopCarts = new List<ShopCartModel>();

            for (int i = 0; i < shopCarts.Count; i++)
            {
                var shopCart = shopCarts[i];
                var shopCartModel = mapper.Map(shopCart);
                shopCartModel.Price *= shopCartModel.Count;
                shopCartPrice += shopCartModel.Price;

                ShopCarts.Add(shopCartModel);

            }

            return ShopCarts;
        }

        public bool Order(int Id,OrderDetailsModel model)
        {
            try
            {
                var shopCarts = db.ShopCartRepository.GetAll(Id);
                var checkOutMapper = new CheckOutMapper();
                var orderDetails = checkOutMapper.Map(model);

                //db.CheckOutRepository.InsertOrderProducts(shopCarts, orderDetails);

                db.CheckOutRepository.Insert(orderDetails);
                foreach (var item in shopCarts)
                {
                    db.CheckOutRepository.InsertOrderProducts(item.Id);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
