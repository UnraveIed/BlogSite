using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager _message = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IActionResult InBox()
        {
            

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

        public IActionResult SendBox()
        {
            var userMail = c.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.Mail == userMail).Select(x => x.WriterId).FirstOrDefault();

            var values = _message.GetSendboxListByWriter(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 model)
        {
            var userMail = c.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.Email).FirstOrDefault();
            var userId = c.Writers.Where(x => x.Mail == userMail).Select(x => x.WriterId).FirstOrDefault();

            model.SenderId = userId;
            model.ReceiverId = 2;
            model.Status = true;
            model.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _message.Add(model);

            return RedirectToAction("InBox");
        }
    }
}
