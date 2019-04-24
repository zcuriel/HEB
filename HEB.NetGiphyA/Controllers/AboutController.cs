using Microsoft.AspNetCore.Mvc;

namespace HEB.NetGiphyA.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
