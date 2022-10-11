using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogSite.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            Context c = new Context();

            var userMail = c.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.Mail == userMail).Select(x => x.WriterId).FirstOrDefault();

            var values = bm.GetListWithCategoryByWriter(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog b)
        {
            Context c = new Context();

            var userMail = c.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.Mail == userMail).Select(x => x.WriterId).FirstOrDefault();

            BlogValidator blogVl = new BlogValidator();
            ValidationResult result = blogVl.Validate(b);
            if (result.IsValid)
            {
                b.Status = true;
                b.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                b.WriterId = writerId;
                bm.Add(b);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult BlogDelete(int id)
        {
            var blogValue = bm.GetById(id);
            bm.Delete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult BlogUpdate(int id)
        {
            List<SelectListItem> categoryValues = (from x in cm.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            var blogValue = bm.GetById(id);
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult BlogUpdate(Blog b)
        {
            Context c = new Context();

            var userMail = c.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.Mail == userMail).Select(x => x.WriterId).FirstOrDefault();
            b.WriterId = writerId;
            b.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.Status = true;
            bm.Update(b);
            return RedirectToAction("BlogListByWriter");
        }
    }

}
