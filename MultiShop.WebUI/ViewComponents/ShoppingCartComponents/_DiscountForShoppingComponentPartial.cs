using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartComponents
{
    public class _DiscountForShoppingComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
