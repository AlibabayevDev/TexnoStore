﻿using TexnoStore.Core.Domain.Entities;
using TexnoStoreWebCore.Models;

namespace TexnoStoreWebCore.Mapper
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
                AddDate = model.AddDate,
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
                AddDate = entity.AddDate,
                Rating = entity.StarCount,
            };
        }
    }
}
