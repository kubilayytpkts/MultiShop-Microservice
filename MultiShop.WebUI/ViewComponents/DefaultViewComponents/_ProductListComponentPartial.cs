using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _ProductListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            var client = _httpClientFactory.CreateClient();
            var requestMessage = await client.GetAsync("https://localhost:7000/api/Products/GetProductsWithByCategoryId/" + categoryId);
            if(requestMessage.IsSuccessStatusCode)
            {
                var jsonData = await requestMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(deserializeData);
            }
            return View(); 
        }
    }
}
