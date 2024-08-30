using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopbarUILayoutComponentView:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
