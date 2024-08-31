using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailComponents
{
    public class _ProductDetailReviewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {  return View(); }
    }
}
