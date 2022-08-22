using TexnoStore.Core.Domain.Entities.Cameras;
using TexnoStore.Models.Cameras;

namespace TexnoStore.Mapper.Cameras
{
    public class CameraImageMapper
    {
        public CamerasImagesModel Map(CamerasImages entity)
        {
            var image = new CamerasImagesModel()
            {
                Id = entity.Id,
                Image=entity.img
            };

            return image;
        }

        public CamerasImages Map(CamerasImagesModel model)
        {
            var image = new CamerasImages()
            {
                Id = model.Id,
                img = model.Image
            };

            return image;
        }
    }
}
