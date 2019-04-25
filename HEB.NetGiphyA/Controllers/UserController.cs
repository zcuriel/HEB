using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Models;
using HEB.NetGiphyA.Util;
using Microsoft.AspNetCore.Mvc;

namespace HEB.NetGiphyA.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Controller that displays the form to register a user in the app
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }        


        /// <summary>
        /// Save the user information in the database and send a notification to be added to the Tenant Directory
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Save(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_userService.VerifyRegisteredUser(user.UserEmail))  // If user not registered
                    {
                        var userDb = ObjectTransformations.TransformViewToDbObj(user);

                        _userService.AddUserRegistration(userDb);
                        ViewBag.IsError = "false";
                        ViewBag.Message = "User registered sucessfully!";
                        // Send Email to the User & Admin
                        Email.sendEmail(user.UserEmail, user.Name);
                        return View();
                    } else
                    {
                        ViewBag.IsError = true;
                        ViewBag.Message = $"User already Registered: '{user.UserEmail}'. Try with a different email!";                        
                    }
                }
                return View("Register");
            }
            catch (System.Exception)
            {
                ViewBag.IsError = true;
                ViewBag.Message = $"Unexpected error ocurred while Registering user: '{user.Name}'. Try again later!";
                return View("Register");
            }
        }

    }
}
