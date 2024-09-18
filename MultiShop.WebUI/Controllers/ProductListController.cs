using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    [Route("ProductList")]
    public class ProductListController : Controller
    {
        [Route("Index/{id}")]
        public IActionResult Index(string id)
        {
            ViewData["categoryId"] = id;
            return View();
        }

        [Route("ProductDetail/{id}")]
        public IActionResult ProductDetail(string id)
        {
            ViewData["productId"] = id;
            return View();
        }
    }
}
