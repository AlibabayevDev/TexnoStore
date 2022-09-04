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
    public class AllProductService : IAllProductService
    {
        private readonly IUnitOfWork db;
        public AllProductService(IUnitOfWork db)
        {
            this.db = db;
        }

        public List<BaseModel> GetAllProduct()
        {
            var products = db.AllProductRepository.GetAllProducts();
            BaseMapper baseMapper = new BaseMapper();
            List<BaseModel> allProducts = new List<BaseModel>();

            for(int i = 0; i < products.Count; i++)
            {
                var product = products[i];
                var productModel = baseMapper.Map(product);
                allProducts.Add(productModel);
            }

            return allProducts;
        }

        public BaseModel AllProduct(int id)
        {
            var allProduct = db.AllProductRepository.AllProducts(id);
            BaseMapper baseMapper = new BaseMapper();
            BaseModel baseModel = new BaseModel();

            var productModel = baseMapper.Map(allProduct);

            return productModel;
        }

        public ShopCartModel QuickViewProduct(int id)
        {
            var shopcart = db.AllProductRepository.QuickViewProduct(id);
            ShopCartModel shopCartModel = new ShopCartModel();
            ShopCartMapper shopCartMapper = new ShopCartMapper();
            var shopcartProduct = shopCartMapper.Map(shopcart);
            return shopcartProduct;
        }
    }
}
