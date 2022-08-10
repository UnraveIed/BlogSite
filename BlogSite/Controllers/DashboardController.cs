using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.blogCount = c.Blogs.Count().ToString();
            ViewBag.userBlogCount = c.Blogs.Where(x => x.WriterId == 1).Count().ToString();
            ViewBag.categoryCount = c.Categories.Count().ToString();
            return View();
        }
    }
}
