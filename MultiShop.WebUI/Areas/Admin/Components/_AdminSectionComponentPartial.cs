using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Components
{
    public class _AdminSectionComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
