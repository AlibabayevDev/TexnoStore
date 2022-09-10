using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Services.Abstract;


namespace TexnoStoreWebCore.Services.Implementations
{
	public class ReviewService : IReviewService
	{
        private readonly IUnitOfWork db;
        public ReviewService(IUnitOfWork db)
        {
            this.db = db;
        }

        public double MiddleStarCount(List<ReviewModel> reviews)
        {
            if(reviews.Count==0)
            {
                return 0;
            }
            double count = 0;
            for(int i = 0; i < reviews.Count; i++)
            {
                count += reviews[i].Rating;
            }
            count /= reviews.Count;

            return Math.Round(count,1);
        }
    }
}
