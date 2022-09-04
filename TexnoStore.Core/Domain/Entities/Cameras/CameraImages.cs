using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.Domain.Entities.Cameras
{
    public class CameraImages
    {
        public int Id { get; set; }
        public virtual Camera camera { get; set; }
        public virtual List<Image> img { get; set; }
    }
}
