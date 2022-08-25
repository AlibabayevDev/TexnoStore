using TexnoStore.Core.Domain.Entities.Cameras;
using TexnoStoreWebCore.Models.Cameras;

namespace TexnoStoreWebCore.Mapper.Cameras
{
    public class CameraImageMapper
    {
        public CamerasImagesModel Map(CameraImages entity)
        {
            var image = new CamerasImagesModel()
            {
                Id = entity.Id,
                Image=entity.img
            };

            return image;
        }

        public CameraImages Map(CamerasImagesModel model)
        {
            var image = new CameraImages()
            {
                Id = model.Id,
                img = model.Image
            };

            return image;
        }
    }
}
