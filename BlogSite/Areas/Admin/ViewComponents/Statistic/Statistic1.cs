using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BlogSite.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetAll().Count;
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            string apiKey = "8d779ebaec28fa0c485e00e3515ea773";

            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Konya&units=metric&mode=xml&appid=" + apiKey;

            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("city").ElementAt(0).Attribute("name").Value;
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            

            return View();
        }
    }
}
