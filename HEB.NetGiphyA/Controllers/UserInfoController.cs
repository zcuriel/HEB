using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HEB.NetGiphyA.Controllers
{
    [Authorize]
    public class UserInfoController : Controller
    {
        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public string GetUserName()
        {
            return User.FindFirst(ClaimTypes.Name).Value;
        }

        public string GetUserEmail()
        {
            return User.FindFirst(ClaimTypes.Email).Value;
        }
    }
}
