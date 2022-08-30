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
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork db;
        public HomeService(IUnitOfWork db)
        {
            this.db = db;
        }
        public void AddToCard(ShopCartModel model)
        {
            ShopCartMapper shopCartMapper = new ShopCartMapper();
            ShopCartModel shopCartModel = new ShopCartModel();
            shopCartModel.ProductId = model.ProductId;
            shopCartModel.UserId = model.UserId;
            shopCartModel.Count = model.Count;
            var shopCart = shopCartMapper.Map(shopCartModel);
            db.ShopCartRepository.Add(shopCart);
        }

        public List<BaseModel> AllProducts()
        {
            var allProducts = db.AllProductRepository.GetAllProducts();

            BaseMapper baseMapper = new BaseMapper();
            List<BaseModel> productsModels = new List<BaseModel>();

            for (int i = 0; i < allProducts.Count; i++)
            {
                var product = allProducts[i];
                var productModel = baseMapper.Map(product);

                productsModels.Add(productModel);
            }

            return productsModels;
        }
    }
}
