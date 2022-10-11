using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager _message = new Message2Manager(new EfMessage2Repository());
        public IActionResult InBox()
        {
            Context c = new Context();

            var userMail = c.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.Mail == userMail).Select(x => x.WriterId).FirstOrDefault();

            var values = _message.GetInboxListByWriter(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var values = _message.GetById(id);
            return View(values);
        }
    }
}
