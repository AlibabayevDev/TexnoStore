﻿using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Domain.Entities.Cameras;
using TexnoStoreWebCore.Models;

namespace TexnoStore.Models.Cameras
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
