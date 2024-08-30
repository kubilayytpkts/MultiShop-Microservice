using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentView:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
