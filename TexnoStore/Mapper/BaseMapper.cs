using TexnoStore.Core.Domain.Entities;
using TexnoStore.Models;

namespace TexnoStore.Mapper
{
    public class BaseMapper
    {
        public BaseEntity Map(BaseModel model)
        {
            var entity = new BaseEntity()
            {
                Id = model.Id,
                Name = model.Name,
                LongDesc = model.LongDesc,
                Price = model.Price,
                OldPrice = model.OldPrice,
                Sale = model.Sale,
                CategoryId = model.CategoryId,
                MainImg = model.MainImg,
                AddDate = model.AddDate,
                ShortDesc = model.ShortDesc,
                ProductType = model.ProductType,
                ProductTypeName = model.ProductTypeName,
            };
            return entity;
        }

        public BaseModel Map(BaseEntity entity)
        {
            var model = new BaseModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                LongDesc = entity.LongDesc,
                Price = entity.Price,
                OldPrice = entity.OldPrice,
                Sale = entity.Sale,
                CategoryId = entity.CategoryId,
                MainImg = entity.MainImg,
                AddDate = entity.AddDate,
                ShortDesc = entity.ShortDesc,
                ProductType = entity.ProductType,
                ProductTypeName= entity.ProductTypeName,
            };
            return model;
        }
    }
}
