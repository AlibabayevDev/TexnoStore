using System.Collections.Generic;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Models.Cameras
{
    public class CamerasImagesModel
    {
        public int Id { get; set; }
        public virtual CameraModel Camera { get; set; }
        public virtual List<Image> Image { get; set; }
    }
}
