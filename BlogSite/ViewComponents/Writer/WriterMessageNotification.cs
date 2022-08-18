using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            var values = mm.GetInboxListByWriter(int.Parse(User.Identity.Name));
            return View(values);
        }
    }
}
