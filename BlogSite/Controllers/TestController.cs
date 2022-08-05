using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
