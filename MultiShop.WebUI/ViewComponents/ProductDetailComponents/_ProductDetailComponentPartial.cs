using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailComponents
{
    public class _ProductDetailComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7000/api/Products/" + id);
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<ProductResultDto>(jsonData);
                return View(deserializeData);
            }
            return View();
        }
    }
}
