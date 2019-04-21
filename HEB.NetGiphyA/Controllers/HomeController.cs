using Microsoft.AspNetCore.Mvc;

namespace HEB.NetGiphyA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
