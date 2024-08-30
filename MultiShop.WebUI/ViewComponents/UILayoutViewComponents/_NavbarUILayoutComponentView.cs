using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentView:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
