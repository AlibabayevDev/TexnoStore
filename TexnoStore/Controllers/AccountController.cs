using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Email;
using TexnoStore.Mapper.Users;
using TexnoStore.Models;
using TexnoStore.Models.Users;

namespace TexnoStore.Controllers
{
    public class EmailLink
    {
        public string email { get; set; }
        public string link { get; set; }
    }

    public class AccountController : Controller
    {
        public LoginMapper LoginMapper = new LoginMapper();
        public static UserViewModel SelectModel = new UserViewModel();
        private static string ConfirmPass { get; set; }
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUnitOfWork db;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IUnitOfWork db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel model)
        {
            if ((model.loginModel.Email == null) || (model.loginModel.Password == null))
            {
                ViewBag.Error = "Username or password is incorrect";
                return View("Index", model);
            }

            var user = userManager.FindByNameAsync(model.loginModel.Email).Result;
            if (user == null)
            {
                ViewBag.Error = "Username or password is incorrect";
                return View("Index", model);
            }

            var signInResult = signInManager.PasswordSignInAsync(user, model.loginModel.Password, true, false).Result;

            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Username or password is incorrect";

            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Regist()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Regist(UserViewModel model)
        {
            if ((model.loginModel.Email == null) || (model.loginModel.Password == null))
            {
                return View("Regist", model);
            }
            if (model.loginModel.Password != model.loginModel.RetypePassword)
            {
                ViewBag.Error1 = "Passwords do not match";
                return View("Regist", model);
            }
            model.user = LoginMapper.Map(model.loginModel);
            var user = userManager.FindByNameAsync(model.loginModel.Email).Result;
            if (user == null)
            {
                try
                {
                    Random rnd = new Random();
                    ConfirmPass = rnd.Next(100000, 999999).ToString();
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Adminstrator", "alibabaev375@mail.ru"));
                    message.To.Add(new MailboxAddress("naren", model.loginModel.Email));
                    message.Subject = "Confirm Password";
                    message.Body = new TextPart("plain")
                    {
                        Text = ConfirmPass
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.mail.ru", 25, false);
                        client.Authenticate("alibabaev375@mail.ru", "UnhvOfx824cPnFhevo3g");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                    SelectModel.loginModel = model.loginModel;
                    return View("Complete", model);
                }
                catch (Exception ex)
                {
                    ViewBag.Error1 = "This email does not exist";
                    return View(model);
                }
            }
            else
            {
                ViewBag.Error1 = "This Email is registered";
                return View(model);

            }
            /*foreach (var i in user.Errors)
            {
                model.ErrorMessage += i.Description;
                TempData["Error"] = model.ErrorMessage;
            }*/
        }



        public IActionResult Complete(UserViewModel model)
        {
            if (model.ConfirmPassword == ConfirmPass)
            {
                model.user = LoginMapper.Map(SelectModel.loginModel);
                if (model.user.PasswordHash != null)
                {

                    var user = userManager.CreateAsync(model.user, model.user.PasswordHash).Result;
                    if (user.Succeeded)
                    {
                        signInManager.SignInAsync(model.user, isPersistent: false);
                        return RedirectToActionPermanent("Index", "Home");
                    }
                    else
                    {
                        foreach (var i in user.Errors)
                        {
                            model.ErrorMessage += i.Description;
                            ViewBag.Error1 = model.ErrorMessage;
                        }
                        return View(model); ;
                    }
                }
            }
            ViewBag.Error1 = "Passwords do not match";
            return View();
        }

        public IActionResult RepeatSend()
        {
            Random rnd = new Random();
            ConfirmPass = rnd.Next(100000, 999999).ToString();
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Adminstrator", "alibabaev375@mail.ru"));
            message.To.Add(new MailboxAddress("naren", SelectModel.loginModel.Email));
            message.Subject = "Confirm Password";
            message.Body = new TextPart("plain")
            {
                Text = ConfirmPass
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.mail.ru", 25, false);
                client.Authenticate("alibabaev375@mail.ru", "UnhvOfx824cPnFhevo3g");
                client.Send(message);
                client.Disconnect(true);
            }
            ViewBag.Error1 = "We resubmitted the code";
            SelectModel.loginModel = SelectModel.loginModel;
            return View("Complete", SelectModel);
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return Content("You have no any access for this page");
        }

        public IActionResult IsAuthenticated()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            if (!ModelState.IsValid)
                return View(email);

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return RedirectToAction(nameof(ForgotPasswordConfirmation));

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);


            //var values = new Dictionary<string, string>()
            //{
            //    { "email", email },
            //    {"link", link }
            //};

            //var content = new FormUrlEncodedContent(values);


            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.PostAsync($"https://localhost:7261/api/EmailPassword/Index/{user.Email}/{link}",content))
            //    {
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            string apiResponse = response.Content.ReadAsStringAsync().Result;
            //            emailLink = JsonConvert.DeserializeObject<string>(apiResponse);
            //            return RedirectToAction("ForgotPasswordConfirmation");
            //        }
            //        else
            //            ViewBag.StatusCode = response.StatusCode;

            //    }
            //}




            EmailSender emailHelper = new EmailSender();
            bool emailResponse = emailHelper.SendEmailPasswordReset(user.Email, link);

            if (emailResponse)
                return RedirectToAction("ForgotPasswordConfirmation");
            else
            {
                // log email failed 
            }
            return View(email);
        }


        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            if (!ModelState.IsValid)
                return View(resetPassword);

            var user = await userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
                RedirectToAction("ResetPasswordConfirmation");

            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                    ModelState.AddModelError(error.Code, error.Description);
                return View();
            }

            return RedirectToAction("ResetPasswordConfirmation");
        }

        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        #region google auth
        [AllowAnonymous]
        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }


        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {
            ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction(nameof(Login));


            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };

            int index = userInfo[0].IndexOf(' ');
            string name = userInfo[0].Split(' ').FirstOrDefault();
            string lastname = userInfo[0].Split(' ').LastOrDefault();

            if (result.Succeeded)
                return RedirectToAction("Index", "Allproduct");
            else
            {
                User user = new User
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    Name = name,
                    LastName = lastname,
                    LoginProvider = "Google",
                    ProviderKey = info.ProviderKey
                };

                var userExist = db.LoginRepository.Get(userInfo[1]);

                if (userExist != null)
                {
                    if (userExist.PasswordHash != null)
                    {
                        user.PasswordHash = userExist.PasswordHash;
                        db.LoginRepository.Update(user);
                        await signInManager.SignInAsync(user, false);

                        return RedirectToAction("Index", "Allproduct");
                    }
                }

                IdentityResult identResult = await userManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Allproduct");

                    //identResult = await userManager.AddLoginAsync(user, info);
                    //if (identResult.Succeeded)
                    //{
                    //    await signInManager.SignInAsync(user, false);
                    //    return View(userInfo);
                    //}
                }
                return AccessDenied();
            }
        }
        #endregion
    }

}
