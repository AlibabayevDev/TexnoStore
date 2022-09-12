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
    public class Service : IService
    {
        public readonly IUnitOfWork db;
        public Service(IUnitOfWork db)
        {
            this.db = db;
        }
        public double MiddleStarCount(int productId)
        {
            var reviewsEntity = db.ReviewRepository.GetAll(productId);
            var mapper = new ReviewMapper();
            List<ReviewModel> reviews = new List<ReviewModel>();
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
    }
}
