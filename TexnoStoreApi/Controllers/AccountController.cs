using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Email;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Models.Users;

namespace TexnoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,IConfiguration configuration, IUnitOfWork db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequestModel model)
        {
            var user = userManager.FindByEmailAsync(model.Email).Result;

            if (user == null)
                return BadRequest("User was not found");

            var signInResult = signInManager.PasswordSignInAsync(user.Email, model.Password, true, false).Result;

            if(signInResult.Succeeded == false)
                return BadRequest("Something went wrong couldn't sign in");

            string token = GenerateToken(user);

            return Ok(new LoginResponseModel()
            {
                Email = user.Email,
                Token = token,
            });
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(configuration["JWT:Key"].ToString());

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                NotBefore = DateTime.UtcNow, //token create time
                IssuedAt = DateTime.UtcNow,  // token create time
                Expires = DateTime.Now.AddDays(15), //Token expires after 15
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            var user = userManager.FindByEmailAsync(email).Result;

            if (user == null)
                return BadRequest("User was not found");

            var token = userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);
            EmailHelper emailHelper = new EmailHelper();

            bool emailResponse = emailHelper.SendEmailPasswordReset(user.Email, link);

            if (emailResponse)
                return Ok(link);

            return BadRequest("Something went wrong");
        }



        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(ResetPassword resetPassword)
        {
            var user = userManager.FindByEmailAsync(resetPassword.Email).Result;
            if (user == null)
                return NotFound("User was not found");

            var resetPassResult = userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password).Result;
            if (resetPassResult.Succeeded == false)
                return BadRequest("Something went wrong");

            string token = GenerateToken(user);

            return Ok(new LoginResponseModel
            {
                Token = token,
                Email = user.Email
            });
        }


    }
}
