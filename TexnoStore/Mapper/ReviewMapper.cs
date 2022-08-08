using TexnoStore.Core.Domain.Entities;
using TexnoStore.Models;

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
                StarCount = model.rating,
                LaptopId = model.LaptopId
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
                rating = entity.StarCount,
                StarCount = entity.StarCount,
                LaptopId = entity.LaptopId
            };
        }
    }
}
