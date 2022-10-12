using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        public IActionResult InBox()
        {
            return View();
        }
    }
}
