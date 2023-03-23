using Microsoft.AspNetCore.Mvc;

namespace Customer_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
