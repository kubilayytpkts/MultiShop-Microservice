using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ContactPageComponents
{
    public class _ContactPageMapeComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
