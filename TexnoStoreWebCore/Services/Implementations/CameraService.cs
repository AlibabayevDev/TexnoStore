using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStoreWebCore.Mapper.Cameras;
using TexnoStoreWebCore.Models.Cameras;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreWebCore.Services.Implementations
{
    public class CameraService : ICameraService
    {
        private readonly CameraMapper cameraMapper = new CameraMapper();
        private readonly IUnitOfWork db;
        public CameraService(IUnitOfWork db)
        {
            this.db = db;
        }

        public List<CameraModel> Cameras()
        {
            var cameras = db.CameraRepository.Cameras();
            List<CameraModel> camerasModels = new List<CameraModel>();

            for(int i = 0; i < cameras.Count; i++)
            {
                var camera = cameras[i];
                var cameraModel = cameraMapper.Map(camera);

                camerasModels.Add(cameraModel);
            }

            return camerasModels;
        }


        public CameraModel CameraById(int id)
        {
            var camera = db.CameraRepository.CameraProduct(id);
            var cameraModel = cameraMapper.Map(camera);
            return cameraModel;
        }


        public List<CameraModel> Username(string username)
        {
            var cameras = db.CameraRepository.SearchCamera(username);
            List<CameraModel> camerasModels = new List<CameraModel>();
            for(int i = 0; i < cameras.Count; i++)
            {
                var camera = cameras[i];
                var cameraModel = cameraMapper.Map(camera);
                camerasModels.Add(cameraModel);
            }

            return camerasModels;
        }
    }
}
