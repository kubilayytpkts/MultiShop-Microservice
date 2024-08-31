using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Components
{
    public class _AdminHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
