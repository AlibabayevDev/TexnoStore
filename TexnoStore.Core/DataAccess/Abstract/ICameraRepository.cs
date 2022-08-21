using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Domain.Entities.Cameras;

namespace TexnoStore.Core.DataAccess.Abstract
{
    public interface ICameraRepository : IMainRepository
    {
        List<Camera> Cameras();
        List<Camera> SearchCamera(string name);
        Camera CameraProduct(int Id);

    }
}
