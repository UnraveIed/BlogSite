using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
