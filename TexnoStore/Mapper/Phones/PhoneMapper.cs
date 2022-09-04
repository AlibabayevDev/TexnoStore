using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Mapper;
using TexnoStore.Models.Phones;

namespace TexnoStore.Mapper.Phones
{
    public class PhoneMapper 
    {
        private readonly PhoneImageMapper laptopImageMapper = new PhoneImageMapper();

        public Phone Map(PhoneModel model)
        {
            var laptop = new Phone()
            {
                Id = model.Id,
                Name = model.Name,
                LongDesc = model.LognDesc,
                Price = model.Price,
                OldPrice = model.OldPrice,
                Sale = model.Sale,
                CategoryId = model.CategoryId,
                PhonesImages = laptopImageMapper.Map(model.PhonesImages),
                ImageId = model.ImageId,
                MainImg = model.MainImg,
            };
            return laptop;
        }

        public PhoneModel Map(Phone entity)
        {
            var laptop = new PhoneModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                LognDesc = entity.LongDesc,
                Price = entity.Price,
                OldPrice = entity.OldPrice,
                Sale = entity.Sale,
                CategoryId = entity.CategoryId,
                PhonesImages = laptopImageMapper.Map(entity.PhonesImages),
                ImageId = entity.ImageId,
                MainImg= entity.MainImg,
            };
            return laptop;
        }
    }
}
