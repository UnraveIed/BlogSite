using BlogSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var comValues = new List<UserComment>
            {
                new UserComment
                {
                    Id=1,
                    Name = "Batuhan"
                },
                new UserComment
                {
                    Id=2,
                    Name = "Samet"
                },
                new UserComment
                {
                    Id=3,
                    Name = "Ilknur"
                },
            };
            return View(comValues);
        }
    }
}
