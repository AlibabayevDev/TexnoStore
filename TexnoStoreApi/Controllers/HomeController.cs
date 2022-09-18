using Microsoft.AspNetCore.Mvc;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUnitOfWorkService service;
        public HomeController(IUnitOfWorkService service)
        {
            this.service = service;
        }

        [Route("AddToCard")]
        [HttpPost]
        public IActionResult AddToCard(ShopCartModel model)
        {
            try
            {
                service.HomeService.AddToCard(model);
                return Ok("Successfully added");
            }
            catch (Exception ex)
            {
                return BadRequest("Something get wrong");
            }
            
        }

        [Route("GetAllProducts")]
        [HttpGet]
        public IActionResult AllProducts()
        {
            var model = service.HomeService.AllProducts();
            return Ok(model);
        }

        [HttpPost]
        [Route("AddSubscribe")]
        public IActionResult AddSubscribe(SubscribeModel model)
        {
            try
            {
                service.SubscribeService.Add(model);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest("something went wrong");
            }
        }
    }
}
