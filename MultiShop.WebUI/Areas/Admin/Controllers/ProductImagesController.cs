using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.ProductImagesDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class ProductImagesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImagesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(string productId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7000/api/ProductImages/"+ productId);
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
                return View(deserializeData);
            }

            return View();
        }
    }
}
