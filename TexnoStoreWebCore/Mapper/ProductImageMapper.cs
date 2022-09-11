using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStoreWebCore.Models;

namespace TexnoStoreWebCore.Mapper
{
    public class ProductImageMapper
    {
        public ProductImagesModel Map(ProductImages model)
        {
            var image = new ProductImagesModel()
            {
                Id = model.Id,
                Image = model.Image,
            };
            return image;
        }

        public ProductImages Map(ProductImagesModel entity)
        {
            var image = new ProductImages()
            {
                Id = entity.Id,
                Image = entity.Image,
            };
            return image;
        }
    }
}
