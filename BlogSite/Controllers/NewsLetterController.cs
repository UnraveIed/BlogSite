using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter n)
        {
            n.MailStatus = true;
            nm.Add(n);
            return PartialView();
        }
    }
}
