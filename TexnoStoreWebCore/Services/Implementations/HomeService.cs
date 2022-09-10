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
                productModel.MiddleStarCount = MiddleStarCount(productModel.ProductId);
                productsModels.Add(productModel);
            }

            return productsModels;
        }

        public double MiddleStarCount(int productId)
        {
            var reviewsEntity = db.ReviewRepository.GetAll(productId);
            var mapper = new ReviewMapper();
            List<ReviewModel> reviews= new List<ReviewModel>();
            for (int i = 0; i < reviewsEntity.Count; i++)
            {
                var review = reviewsEntity[i];
                var reviewModel = mapper.Map(review);
                reviews.Add(reviewModel);
            }
            
            if (reviews.Count == 0)
            {
                return 0;
            }
            double count = 0;
            for (int i = 0; i < reviews.Count; i++)
            {
                count += reviews[i].Rating;
            }
            count /= reviews.Count;

            return Math.Round(count, 1);
        }

        public int ProductName(int productId, int typeId)
        {
            if (typeId == 1)
            {
                var laptop = db.LaptopRepository.LaptopProduct(productId);
                return laptop.Id;
            }
            else if (typeId == 2)
            {
                var phone = db.PhoneRepository.PhoneProduct(productId);
                return phone.Id;
            }
            else if (typeId == 3)
            {
                var camera = db.CameraRepository.CameraProduct(productId);
                return camera.Id;
            }

            return 0;
        }
    }
}
