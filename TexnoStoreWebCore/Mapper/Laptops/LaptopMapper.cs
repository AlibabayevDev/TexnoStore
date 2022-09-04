using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStore.Mapper;
using TexnoStoreWebCore.Models.Laptops;

namespace TexnoStoreWebCore.Mapper.Laptops
{
    public class LaptopMapper 
    {
        private readonly CategoryMapper categoryMapper = new CategoryMapper();

        private readonly LaptopImageMapper laptopImageMapper = new LaptopImageMapper();

        public Laptop Map(LaptopModel model)
        {
            var laptop = new Laptop()
            {
                Id = model.Id,
                Name = model.Name,
                LongDesc = model.LongDesc,
                Price = model.Price,
                OldPrice = model.OldPrice,
                Sale = model.Sale,
                LaptopsImages = laptopImageMapper.Map(model.LaptopsImages),
                ImageId = model.ImageId,
                MainImg = model.MainImg,
                Brand = model.Brand,
                ScreenMatrix = model.ScreenMatrix,
                AddDate = model.AddDate,
                RAM = model.RAM,
                Display = model.Display,
                GraphicsCoprocessor = model.GraphicsCoprocessor,
                HardDrive = model.HardDrive,
                ScreenSize = model.ScreenSize,
                OperatingSystem = model.OperatingSystem,
                Processor = model.Processor,
                Series = model.Series,
                Weight = model.Weight,
                ShortDesc= model.ShortDesc,
                ProductId = model.ProductId,
                ProductType = model.ProductType,
                ProductTypeName = model.ProductTypeName,
            };
            return laptop;
        }

        public LaptopModel Map(Laptop entity)
        {
            var laptop = new LaptopModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                LongDesc = entity.LongDesc,
                Price = entity.Price,
                OldPrice = entity.OldPrice,
                Sale = entity.Sale,
                LaptopsImages = laptopImageMapper.Map(entity.LaptopsImages),
                ImageId = entity.ImageId,
                MainImg= entity.MainImg,
                Brand = entity.Brand,
                ScreenMatrix = entity.ScreenMatrix,
                AddDate = entity.AddDate,
                RAM = entity.RAM,
                Display = entity.Display,
                GraphicsCoprocessor = entity.GraphicsCoprocessor,
                HardDrive = entity.HardDrive,
                ScreenSize = entity.ScreenSize,
                OperatingSystem = entity.OperatingSystem,
                Processor = entity.Processor,
                Series = entity.Series,
                Weight = entity.Weight,
                ShortDesc = entity.ShortDesc,
                ProductId = entity.ProductId,
                ProductType = entity.ProductType,
                ProductTypeName = entity.ProductTypeName,
            };
            return laptop;
        }
    }
}
