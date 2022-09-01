using Microsoft.AspNetCore.Mvc;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PhoneController : ControllerBase
	{
		private readonly IUnitOfWorkService phoneService;
		public PhoneController(IUnitOfWorkService phoneService) 
		{
			this.phoneService = phoneService;
		}

		[HttpGet]
		[Route("GetAll")]
		public IActionResult Phones()
		{
			try
			{
				var phones = phoneService.PhoneService.Phones();
				if(phones == null)
					return NotFound("Product not found");

				return Ok(phones);
			}
			catch
			{
				BadRequest("something went wrong");
			}

	       return BadRequest("something went wrong");
		}

		[HttpGet]
		[Route("PhoneProduct/{id:int}")]
		public IActionResult PhoneProduct(int id)
		{
			try
			{
				var phoneProduct = phoneService.PhoneService.PhoneProduct(id);
				if (phoneProduct == null)
					return NotFound("Product not found");

				return Ok(phoneProduct);
			}
			catch
			{
				BadRequest("something went wrong");
			}
			return BadRequest("something went wrong");
		}

		[HttpGet]
		[Route("Search")]
		public IActionResult SearchPhone(string name)
		{
			try
			{
				var phone = phoneService.PhoneService.SearchPhones(name);
				if (phone == null)
					return NotFound("Product not found");

				return Ok(phone);
			}
			catch
			{
				BadRequest("something went wrong");
			}

			return BadRequest("something went wrong");
		}
	}
}
