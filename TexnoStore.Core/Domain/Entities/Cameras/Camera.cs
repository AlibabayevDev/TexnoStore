using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.Domain.Entities.Cameras
{
    public class Camera : BaseEntity
    {
        public int Id { get; set; }

        public string Company { get; set; }

        public string OpticalZoom { get; set; }

        public string Color { get; set; }

        public int ProductId { get; set; }

        public int ImageId { get; set; }

        public Category Category { get; set; }

        public CamerasImages CamerasImages { get; set; }
    }
}
