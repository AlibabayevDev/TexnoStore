using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Domain.Entities.Cameras;

namespace TexnoStore.Models.Cameras
{
    public class CameraModel : BaseModel
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string OpticalZoom { get; set; }
        public string Color { get; set; }
        public int ProductId { get; set; }
        public int ImageId { get; set; }
        public Category Category { get; set; }
        public CamerasImagesModel CameraImages { get; set; }
    }
}
