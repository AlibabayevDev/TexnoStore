using Microsoft.AspNetCore.Mvc;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllProductController : ControllerBase
    {
        private readonly IUnitOfWorkService allProductService;
        public AllProductController(IUnitOfWorkService allProductService)
        {
            this.allProductService = allProductService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var allProduct = allProductService.AllProductService.GetAllProduct();
                if (allProduct == null)
                    return NotFound("Products not found");

                return Ok(allProduct);
            }
            catch(Exception ex)
            {
                return base.BadRequest(new ProblemDetails() { Title = ex.Message, Detail = ex.ToString() });
            }
        }

        [HttpGet]
        [Route("GetAllById/{id}")]
        public IActionResult GetAllById(int id)
        {
            try
            {
                var allProduct = allProductService.AllProductService.AllProduct(id);
                if (allProduct == null)
                    return NotFound("Product not found");

                return Ok(allProduct);
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet]
        [Route("QuickView/{id}")]
        public IActionResult QuickViewProduct(int id)
        {
            try
            {
                var product = allProductService.AllProductService.QuickViewProduct(id);
                if (product == null)
                    return NotFound("Product not found");

                return Ok(product);
            }
            catch(HttpRequestException ex)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
