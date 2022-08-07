using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogSite.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult PartialAddComment(Comment c)
        {
            c.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Status = true;
            c.BlogId = 10;
            cm.Add(c);
            return PartialView();
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            var values = cm.GetAll(id);
            return PartialView(values);
        }
    }
}
