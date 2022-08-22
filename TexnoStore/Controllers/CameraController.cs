using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Mapper;
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

        public IActionResult CameraProduct(int id)
        {
            var cameras = db.CameraRepository.Cameras();

            List<CameraModel> cameraModels = new List<CameraModel>();
            CameraMapper cameraMapper = new CameraMapper();

            for(int i = 0; i < cameras.Count; i++)
            {
                var camera = cameras[i];
                var cameraModel = cameraMapper.Map(camera);

                cameraModels.Add(cameraModel);
            }
            var model = new CameraListViewModel()
            {
                Camera = cameraModels.FirstOrDefault(x => x.Id == id)
            };

            return View(model);
        }


        public IActionResult Review(CameraListViewModel viewModel, int rating)
        {
            viewModel.Camera = SelectedModel;

            if (ModelState.IsValid == false)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
                var errorMessage = errors.Aggregate((message, value) =>
                {
                    if (message.Length == 0)
                        return value;

                    return message + ", " + value;
                });

                TempData["Message"] = errorMessage;
                return RedirectToAction("CameraProduct", new { id = viewModel.Camera.Id });
            }

            ReviewMapper reviewMapper = new ReviewMapper();
            viewModel.Review.Rating = rating;
            viewModel.Review.ProductId = SelectedModel.Id;

            var review = reviewMapper.Map(viewModel.Review);
            try
            {
                db.ReviewRepository.Add(review);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong";
            }


            return CameraProduct(viewModel.Camera.Id);
        }
    }
}
