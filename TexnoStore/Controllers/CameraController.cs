using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Mapper.Cameras;
using TexnoStore.Models.Cameras;

namespace TexnoStore.Controllers
{
    public class CameraController : BaseController
    {
        private readonly IUnitOfWork db;
        public static CameraModel SelectedModel { get; set; }

        public CameraController(IUnitOfWork db) : base(db)
        {
            this.db = db;
        }
         
        public IActionResult Index()
        {
            var cameras = db.CameraRepository.Cameras();

            CameraMapper cameraMapper = new CameraMapper();

            List<CameraModel> camerasModel = new List<CameraModel>();

            for( int i = 0; i < cameras.Count; i++)
            {
                var camera = cameras[i];
                var cameraModel = cameraMapper.Map(camera);

                camerasModel.Add(cameraModel);
            }

            var model = new CameraListViewModel()
            {
                Cameras = camerasModel,
            };

            return View(model);
        }
    }
}
