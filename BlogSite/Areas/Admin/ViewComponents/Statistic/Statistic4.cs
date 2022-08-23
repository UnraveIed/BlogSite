using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Admins.Where(x => x.AdminId == 3).Select(x => x.Name).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x=>x.AdminId==3).Select(x => x.Image).FirstOrDefault();
            ViewBag.v3 = c.Admins.Where(x=>x.AdminId==3).Select(x => x.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
