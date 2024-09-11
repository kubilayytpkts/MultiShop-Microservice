using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.FeatureDtos;
using MultiShop.WebUI.Areas.Admin.Controllers;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FeatureDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/Feature");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(data);
            }

            return View();
        }
    }
}
