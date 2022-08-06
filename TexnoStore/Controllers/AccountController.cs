using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Mapper.Users;
using TexnoStore.Models.Users;

namespace TexnoStore.Controllers
{
    public class AccountController : Controller
    {
        public LoginMapper LoginMapper=new LoginMapper();
        public static UserViewModel SelectModel=new UserViewModel();
        private static string ConfirmPass { get; set; }
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
            if((model.loginModel.Email == null) || (model.loginModel.Password == null))
            {
                return View(model);
            }

            var user = userManager.FindByNameAsync(model.loginModel.Email).Result;
            if (user == null)
            {
                TempData["Message"] = "Username or password is incorrect";
                return View(model);
            }
            
            var signInResult = signInManager.PasswordSignInAsync(user, model.loginModel.Password, true, false).Result;

            if(signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["Message"] = "Username or password is incorrect";
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Regist( )
        {
            return View();
        }


        [HttpPost]
        public IActionResult Regist(UserViewModel model)
        {
            if ((model.loginModel.Email == null) || (model.loginModel.Password == null))
            {
                return View("Index",model);
            }
            if (model.loginModel.Password != model.loginModel.RetypePassword)
            {
                TempData["Error"] = "Passwords do not match";
                return View("Index", model);
            }
            model.user = LoginMapper.Map(model.loginModel);
            var user = userManager.FindByNameAsync(model.loginModel.Email).Result;
            if(user==null)
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
                    TempData["Error"] = "This email does not exist";
                    return RedirectToAction("Index", model);
                }
            }
            else
            {
                TempData["Error"] = "This Email is registered";
                return RedirectToAction("Index", model);

            }
            /*foreach (var i in user.Errors)
            {
                model.ErrorMessage += i.Description;
                TempData["Error"] = model.ErrorMessage;
            }*/
        }



        public IActionResult Complete(UserViewModel model)
        {
            if(model.ConfirmPassword == ConfirmPass)
            {
                model.user = LoginMapper.Map(SelectModel.loginModel);
                if (model.user.PasswordHash != null)
                {
                    
                    var user = userManager.CreateAsync(model.user, model.user.PasswordHash).Result;
                    if (user.Succeeded)
                    {
                        var signInResult = signInManager.PasswordSignInAsync(model.user, model.user.PasswordHash, true, false).Result;
                        
                        if (signInResult.Succeeded)
                        {
                            return RedirectToActionPermanent("Index", "Home");
                        }
                    }
                    else
                    {
                        foreach (var i in user.Errors)
                        {
                            model.ErrorMessage += i.Description;
                            ViewBag.Error = model.ErrorMessage;
                        }
                        return View(model); ;
                    }
                }
            }
            return RedirectToAction("Index","Home");
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
            ViewBag.Message = "We resubmitted the code";
            SelectModel.loginModel = SelectModel.loginModel;
            return View("Complete", SelectModel);
        }

        [Authorize]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account"); 
        }

        public IActionResult AccessDenied()
        {
            return Content("You have no any access for this page");
        } 
    }
        
}
