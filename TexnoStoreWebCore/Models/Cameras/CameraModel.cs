using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities;
using TexnoStoreWebCore.Models.Cameras;

namespace TexnoStoreWebCore.Models.Cameras
{
    public class CameraModel : BaseModel
    {
        public string Company { get; set; }
        public string OpticalZoom { get; set; }
        public string Color { get; set; }
        public int ImageId { get; set; }
        public Category Category { get; set; }
        public CamerasImagesModel CameraImages { get; set; }
    }
}
