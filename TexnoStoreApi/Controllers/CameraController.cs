using Microsoft.AspNetCore.Mvc;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly IUnitOfWorkService cameraService;
        public CameraController(IUnitOfWorkService cameraService)
        {
            this.cameraService = cameraService;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {  
                var cameras = cameraService.CameraService.Cameras();
                if(cameras == null)
                    return BadRequest("Something went wrong");

                return Ok(cameras);
            }
            catch
            {
                BadRequest("something went wrong");
            }

            return BadRequest("something went wrong");
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var camera = cameraService.CameraService.CameraById(id);
                if (camera == null)
                    return BadRequest("Data not found");

                return Ok(camera);
            }
            catch
            {
                return BadRequest("Someting went wrong");
            }
        }

    }
}
