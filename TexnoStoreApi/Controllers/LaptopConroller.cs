using Microsoft.AspNetCore.Mvc;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopConroller : ControllerBase
    {
        public readonly IUnitOfWorkService service;
        public LaptopConroller(IUnitOfWorkService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var laptops = service.LaptopService.Laptops();
                if (laptops == null)
                    return BadRequest("Something went wrong");

                return Ok(laptops);
            }
            catch
            {
                BadRequest("something went wrong");
            }

            return BadRequest("something went wrong");
        }
        [HttpGet]
        [Route("GetLaptop/{id}")]
        public IActionResult GetLaptop(int id)
        {
            try
            {
                var laptop = service.LaptopService.LaptopProduct(id);

                return Ok(laptop);
            }
            catch
            {
                return BadRequest("something went wrong");
            }
        }

        

    }
}
