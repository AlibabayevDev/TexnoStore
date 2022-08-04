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
                StarCount = model.StarCount,
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
                StarCount = entity.StarCount,
            };
        }
    }
}
