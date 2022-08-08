using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
