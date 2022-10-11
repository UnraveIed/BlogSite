using BlogSite.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class WriterController : Controller
    {
        WriterManager _writer = new WriterManager(new EfWriterRepository());

        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }
        
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            Context c = new Context();
            //var userMail = context.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.Email).FirstOrDefault();
            //var userId = context.Writers.Where(x => x.Mail == userMail).Select(x => x.WriterId).FirstOrDefault();
            //var writerValues = _writer.GetById(userId);
            //return View(writerValues);

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdate_VM model = new();
            model.Mail = values.Email;
            model.NameSurname = values.NameSurname;
            model.ImageUrl = values.ImageUrl;
            model.UserName = values.UserName;

            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdate_VM model)
        {
            //WriterValidator wl = new WriterValidator();
            //ValidationResult result = wl.Validate(model);
            //if (result.IsValid)
            //{
            //    _writer.Update(model);
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.NameSurname;
            values.ImageUrl = model.ImageUrl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
            values.Email = model.Mail;

            var result = await _userManager.UpdateAsync(values);

            return RedirectToAction("Index","Dashboard");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage model)
        {
            Writer w = new Writer();
            if (model.Image != null)
            {
                var extension = Path.GetExtension(model.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                model.Image.CopyTo(stream);
                w.Image = "/WriterImageFiles/" + newImageName;
            }
            w.Mail = model.Mail;
            w.Name = model.Name;
            w.About = model.About;
            w.Status = true;
            w.Password = model.Password;
            
            _writer.Add(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
