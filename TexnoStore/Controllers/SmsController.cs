using Microsoft.AspNetCore.Mvc;
using System;
using TexnoStoreWebCore.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TexnoStore.Controllers
{
    public class SmsController : Controller
    {
        public IActionResult Index(SmsModel model)
        { 
            if (ModelState.IsValid)
            {
                try
                {
                    // Find your Account Sid and Auth Token at twilio.com/user/account 
             //       const string accountSid = "ISfbc616cb535a43f49d185e47e9b219ff";
                    const string accountSid = "AC9434c0ae003927be8961a2b3944392fe";
                    const string authToken = "7ab2cb2c784adb1dc00b7d1beb43a2eb";
                    TwilioClient.Init(accountSid, authToken);

                    var to = new PhoneNumber("+994" + model.Mobile);
                    var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber("+994773581006"), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ). 
                    body: $"Hello {model.Message} !! Welcome to Asp.Net Core With Twilio SMS API !!");

                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Registered Successfully !!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Registration Failure : {ex.Message} ");
                }

            }

            return View();
        }
    }
}
