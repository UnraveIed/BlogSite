using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var userMail = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x=>x.Mail == userMail).Select(y=>y.WriterId).FirstOrDefault();
            var values = wm.GetById(writerId);
            return View(values);
        }
    }
}
