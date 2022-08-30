using TexnoStore.Core.Domain.Entities;
using TexnoStore.Models;
using TexnoStoreWebCore.Models;

namespace TexnoStore.Mapper
{
    public class ReviewMapper
    {
        public Review Map(ReviewModel model)
        {
            return new Review()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Message = model.Message,
                ProductId = model.ProductId,
                StarCount = model.Rating,
            };
        }


        public ReviewModel Map(Review entity)
        {
            return new ReviewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Message = entity.Message,
                ProductId = entity.ProductId,
                Rating = entity.StarCount,
            };
        }
    }
}
