
using Microsoft.AspNetCore.Mvc;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCartController : ControllerBase
    {
        private readonly IUnitOfWorkService service;
        private readonly IUnitOfWork db;
        public ShopCartController(IUnitOfWorkService service,IUnitOfWork db)
        {
            this.db = db;
            this.service = service;
        }

        [HttpGet]
        [Route("GetShopCartList")]
        public IActionResult ShopCartList()
        {
            var user = db.LoginRepository.Get(User.Identity.Name);
            var shopCartList = service.ShopCartService.ShopCartList(user.Id);

            return Ok(shopCartList);
        }

        [HttpPut]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.ShopCartService.Delete(id);
                return Ok("Deleted");
            }
            catch
            {
                return BadRequest("something get wrong");
            }

        }
    }
}
