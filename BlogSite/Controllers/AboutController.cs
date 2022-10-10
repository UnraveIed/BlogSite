using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var values = am.GetAll();
            return View(values);
        }

       

        public PartialViewResult SocialMediaAbout()
        {
            
            return PartialView();
        }
    }
}
