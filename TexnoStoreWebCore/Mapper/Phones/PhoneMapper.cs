using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Mapper;
using TexnoStoreWebCore.Models.Phones;

namespace TexnoStoreWebCore.Mapper.Phones
{
    public class PhoneMapper 
    {
        private readonly CategoryMapper categoryMapper = new CategoryMapper();

        private readonly ProductImageMapper laptopImageMapper = new ProductImageMapper();

        public Phone Map(PhoneModel model)
        {
            var laptop = new Phone()
            {
                Id = model.Id,
                Name = model.Name,
                LongDesc = model.LongDesc,
                Price = model.Price,
                OldPrice = model.OldPrice,
                Sale = model.Sale,
                PhonesImages = laptopImageMapper.Map(model.PhonesImages),
                ImageId = model.ImageId,
                MainImg = model.MainImg,
                ProductTypeName = model.ProductTypeName,
                ProductId = model.ProductId,
                ProductType = model.ProductType,
            };
            return laptop;
        }

        public PhoneModel Map(Phone entity)
        {
            var laptop = new PhoneModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                LongDesc = entity.LongDesc,
                Price = entity.Price,
                OldPrice = entity.OldPrice,
                Sale = entity.Sale,
                PhonesImages = laptopImageMapper.Map(entity.PhonesImages),
                ImageId = entity.ImageId,
                MainImg= entity.MainImg,
                ProductTypeName = entity.ProductTypeName,
                ProductType = entity.ProductType,
                ProductId = entity.ProductId,
            };
            return laptop;
        }
    }
}
