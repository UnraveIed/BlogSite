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
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y=>y.Email).FirstOrDefault();
            var userId = c.Writers.Where(x => x.Mail == userMail).Select(x => x.WriterId).FirstOrDefault();
            ViewBag.blogCount = c.Blogs.Count().ToString();
            ViewBag.userBlogCount = c.Blogs.Where(x => x.WriterId == userId).Count().ToString();
            ViewBag.categoryCount = c.Categories.Count().ToString();
            return View();
        }
    }
}
