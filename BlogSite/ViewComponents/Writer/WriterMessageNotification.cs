using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var userMail = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.Mail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerId);
            return View(values);
        }
    }
}
