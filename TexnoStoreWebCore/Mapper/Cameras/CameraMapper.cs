using TexnoStore.Core.Domain.Entities.Cameras;
using TexnoStoreWebCore.Models.Cameras;

namespace TexnoStoreWebCore.Mapper.Cameras
{
    public class CameraMapper
    {
        private readonly CategoryMapper categoryMapper = new CategoryMapper();

        private readonly ProductImageMapper cameraImageMapper = new ProductImageMapper();

        public Camera Map(CameraModel model)
        {
            var camera = new Camera()
            {
                Id = model.Id,
                Company = model.Company,
                OpticalZoom = model.OpticalZoom,
                Color = model.Color,
                CameraImages = cameraImageMapper.Map(model.CameraImages),
                ProductId = model.ProductId,
                ImageId = model.ImageId,
                MainImg = model.MainImg,
                Name = model.Name,
                ProductType = model.ProductType,
                Price = model.Price,
                ProductTypeName = model.ProductTypeName,
                OldPrice = model.OldPrice,
                AddDate = model.AddDate,
                LongDesc = model.LongDesc,
                ShortDesc = model.ShortDesc,
                Sale = model.Sale,
            };

            return camera;
        }

        public CameraModel Map(Camera entity)
        {
            var camera = new CameraModel()
            {
                Id = entity.Id,
                Company = entity.Company,
                OpticalZoom = entity.OpticalZoom,
                Color = entity.Color,
                CameraImages = cameraImageMapper.Map(entity.CameraImages),
                ProductId = entity.ProductId,
                ImageId = entity.ImageId,
                MainImg = entity.MainImg,
                Name= entity.Name,
                ProductType = entity.ProductType,
                Price = entity.Price,
                ProductTypeName = entity.ProductTypeName,
                OldPrice = entity.OldPrice,
                AddDate = entity.AddDate,
                LongDesc = entity.LongDesc,
                ShortDesc = entity.ShortDesc,
                Sale = entity.Sale,
            };

            return camera;
        }

    }
}
