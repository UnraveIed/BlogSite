using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.BlogId).Select(x=>x.Title).Take(1).FirstOrDefault();
            return View();
        }
    }
}
