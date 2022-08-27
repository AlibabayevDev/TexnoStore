﻿using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStoreWebCore.Models.Laptops;

namespace TexnoStoreWebCore.Mapper.Laptops
{
    public class LaptopImageMapper
    {
        public LaptopsImagesModel Map(LaptopsImages model)
        {
            var image = new LaptopsImagesModel()
            {
                Id = model.Id,
                Image = model.Img,
            };
            return image;
        }

        public LaptopsImages Map(LaptopsImagesModel entity)
        {
            var image = new LaptopsImages()
            {
                Id = entity.Id,
                Img = entity.Image,
            };
            return image;
        }
    }
}