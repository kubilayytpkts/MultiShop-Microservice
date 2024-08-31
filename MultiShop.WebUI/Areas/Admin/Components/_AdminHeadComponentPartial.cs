using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Components
{
    public class _AdminHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
