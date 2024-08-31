using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailComponents
{
    public class _ProductDetailInformationComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {  return View(); }
    }
}
