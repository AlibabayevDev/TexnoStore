using Microsoft.AspNetCore.Mvc;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraService cameraService;
        public CameraController(ICameraService cameraService)
        {
            this.cameraService = cameraService;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                var cameras = cameraService.Cameras();
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
                var camera = cameraService.CameraById(id);
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
