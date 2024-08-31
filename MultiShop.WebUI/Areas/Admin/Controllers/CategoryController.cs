using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CategoryDto;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/Categories");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var stringData = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(stringData);
            }

            return View();
        }
    }
}
