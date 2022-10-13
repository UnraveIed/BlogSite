using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        Message2Manager manager = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == userMail).Select(x => x.Id).FirstOrDefault();
            var values = manager.GetInboxListByWriter(userId);


            return View(values);
        }

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == userMail).Select(x => x.Id).FirstOrDefault();
            var values = manager.GetSendboxListByWriter(userId);


            return View(values);
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(Message2 model)
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == userMail).Select(x => x.Id).FirstOrDefault();

            model.SenderId = userId;
            model.ReceiverId = 2;
            model.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            model.Status = true;
            manager.Add(model);

            return View();
        }


    }
}
