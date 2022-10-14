using BlogSite.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogSite.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignIn_VM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index","Login");
                }
            }
            return View();
            
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }



        //[HttpPost] 
        //public async Task<IActionResult> Index(Writer w)
        //{
        //    Context c = new Context();
        //    var dataValue = c.Writers.FirstOrDefault(x=> x.Mail == w.Mail && x.Password == w.Password);
        //    if (dataValue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Email, dataValue.Mail),
        //            new Claim(ClaimTypes.Name, dataValue.WriterId.ToString()),
        //        };

        //        var userIdentity = new ClaimsIdentity(claims,"a");

        //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

        //        await HttpContext.SignInAsync(principal);

        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}

//Context c = new Context();
//var dataValue = c.Writers.FirstOrDefault(x => x.Mail == w.Mail && x.Password == w.Password);
//if (dataValue != null)
//{
//    HttpContext.Session.SetString("username", w.Mail);
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View();
//}
