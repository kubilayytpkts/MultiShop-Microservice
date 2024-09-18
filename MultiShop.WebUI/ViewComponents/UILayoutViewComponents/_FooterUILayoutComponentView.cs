using MessagePack.Resolvers;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.AboutDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentView : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterUILayoutComponentView(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string defaultAboutId = "66e9f6f296255582f3817d8c"; //Default About ıd

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7000/api/About/"+defaultAboutId);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<ResultAboutDto>(jsonData);
                return View(deserializeData);
            }
            return View();
        }
    }
}
