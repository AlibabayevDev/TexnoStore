using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStoreWebCore.Mapper;
using TexnoStoreWebCore.Mapper.Laptops;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Models.Laptops;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreWebCore.Services.Implementations
{
    public class LaptopService : ILaptopService
    {
        public readonly IUnitOfWork db;
        public readonly IReviewService reviewService;
        public LaptopService(IUnitOfWork db,IReviewService reviewService)
        {
            this.db = db;
            this.reviewService = reviewService;
        }

        public List<LaptopModel> Laptops()
        {
            var laptops = db.LaptopRepository.Laptops();

            LaptopMapper laptopMapper = new LaptopMapper();
            List<LaptopModel> laptopModels = new List<LaptopModel>();

            for (int i = 0; i < laptops.Count; i++)
            {
                var laptop = laptops[i];
                var laptopModel = laptopMapper.Map(laptop);
                laptopModel.MiddleStarCount = reviewService.MiddleStarCount(laptopModel.ProductId);
                laptopModels.Add(laptopModel);
            }

            return laptopModels;
        }


        public LaptopModel LaptopProduct(int id)
         {
            var laptop = db.LaptopRepository.LaptopProduct(id);

            LaptopMapper laptopMapper = new LaptopMapper();

            var laptopModel = laptopMapper.Map(laptop);
            laptopModel.MiddleStarCount = reviewService.MiddleStarCount(laptopModel.ProductId);

            return laptopModel;
        }

        public List<ReviewModel> Reviews(int id)
        {
            var reviews = db.ReviewRepository.GetAll(id);
            ReviewMapper mapper = new ReviewMapper();
            List<ReviewModel> reviewsModels = new List<ReviewModel>();
            for (int i = 0; i < reviews.Count; i++)
            {
                var laptop = reviews[i];
                var laptopModel = mapper.Map(laptop);

                reviewsModels.Add(laptopModel);
            }
            return reviewsModels;
        }

        public string AddReview(ReviewModel model)
        {
            string ErrorMessage;

            ReviewMapper reviewMapper = new ReviewMapper();

            var review = reviewMapper.Map(model);
            try
            {
                db.ReviewRepository.Add(review);
                ErrorMessage = "Succesfully added";

            }
            catch (Exception ex)
            {
                ErrorMessage = "Something went wrong";
            }

            return ErrorMessage;
        }
    }
}
