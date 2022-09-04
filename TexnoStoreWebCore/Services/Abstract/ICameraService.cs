using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStoreWebCore.Models.Cameras;

namespace TexnoStoreWebCore.Services.Abstract
{
    public interface ICameraService
    {
        List<CameraModel> Cameras();
        CameraModel CameraById(int id);
        List<CameraModel> Username(string username);
    }
}
