using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    [Route("ProductList")]
    public class ProductListController : Controller
    {
        [Route("Index/{id}")]
        public IActionResult Index(string id)
        {
            ViewData["id"] = id;
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}
