using BusinessLayer.Concrete;
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
            var values = _message.GetInboxListByWriter(int.Parse(User.Identity.Name));
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
