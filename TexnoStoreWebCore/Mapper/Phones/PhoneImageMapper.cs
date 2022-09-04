using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStoreWebCore.Models.Phones;

namespace TexnoStoreWebCore.Mapper.Phones
{
    public class PhoneImageMapper
    {
        public PhonesImagesModel Map(PhonesImages model)
        {
            var image = new PhonesImagesModel()
            {
                Id = model.Id,
                Image = model.Img,
            };
            return image;
        }

        public PhonesImages Map(PhonesImagesModel entity)
        {
            var image = new PhonesImages()
            {
                Id = entity.Id,
                Img = entity.Image,
            };
            return image;
        }
    }
}
