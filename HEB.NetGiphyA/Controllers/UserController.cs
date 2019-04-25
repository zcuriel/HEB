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

        public IActionResult Register()
        {
            return View();
        }        

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Save(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userDb = ObjectTransformations.TransformViewToDbObj(user);
                    _userService.AddUserRegistration(userDb);
                    ViewBag.IsError = "false";
                    ViewBag.Message = "User registered sucessfully!";
                    // Send Email to the User & Admin
                    //Email.sendEmail(user.UserEmail, user.Name);
                    return View();
                }
                return RedirectToAction(nameof(Register));
            }
            catch (System.Exception)
            {
                ViewBag.IsError = true;
                ViewBag.Message = $"Unexpected error ocurred while Registering user: '{user.Name}'. Try again later!";
                return RedirectToAction(nameof(Register));
            }
        }

    }
}
