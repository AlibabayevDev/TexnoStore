using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Email;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Models.Users;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly IUnitOfWorkService service;
        private readonly IUnitOfWork db;
        public CheckOutController(IUnitOfWorkService service,IUnitOfWork db)
        {
            this.db = db;
            this.service = service;
        }

        [HttpGet]
        [Route("CheckOutProducts")]
        public IActionResult CheckOutProducts()
        {
            try
            {
                var user = db.LoginRepository.Get(User.Identity.Name);
                var products = service.CheckOutService.CheckOutProducts(user.Id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest("Something get wrong");
            }
            
        }


    }
}
