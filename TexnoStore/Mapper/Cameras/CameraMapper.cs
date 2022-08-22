using TexnoStore.Core.Domain.Entities.Cameras;
using TexnoStore.Models.Cameras;

namespace TexnoStore.Mapper.Cameras
{
    public class CameraMapper
    {
        private readonly CategoryMapper categoryMapper = new CategoryMapper();

        private readonly CameraImageMapper cameraImageMapper = new CameraImageMapper();

        public Camera Map(CameraModel model)
        {
            var camera = new Camera()
            {
                Id = model.Id,
                Company = model.Company,
                OpticalZoom = model.OpticalZoom,
                Color = model.Color,
                CamerasImages = cameraImageMapper.Map(model.CameraImages),
                ProductId = model.ProductId,
                ImageId = model.ImageId,
                Name = model.Name,
                LongDesc = model.LognDesc,
                Price = model.Price,
                OldPrice = model.OldPrice,
                Sale = model.Sale,
                MainImg = model.MainImg,
                ProductType = model.ProductType,
                ProductTypeName = model.ProductTypeName,
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
                CameraImages = cameraImageMapper.Map(entity.CamerasImages),
                ProductId = entity.ProductId,
                ImageId = entity.ImageId,
                Name = entity.Name,
                Price = entity.Price,
                OldPrice = entity.OldPrice,
                Sale = entity.Sale,
                MainImg = entity.MainImg,
                ProductType = entity.ProductType,
                ProductTypeName = entity.ProductTypeName,
            };

            return camera;
        }

    }
}
