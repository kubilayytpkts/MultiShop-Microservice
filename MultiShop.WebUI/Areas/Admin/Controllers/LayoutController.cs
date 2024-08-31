using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
