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
                CameraImages = cameraImageMapper.Map(model.CameraImages),
                ProductId = model.ProductId,
                ImageId = model.ImageId,
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
            };

            return camera;
        }

    }
}
